using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private bool gravityNullified;
    public bool GravityNullified
    {
        get => gravityNullified;
        set => gravityNullified = value;
    }

    [SerializeField] private float maxHeight;

    public float MaxHeight
    {
        get => maxHeight;
        set => maxHeight = value;
    }

    [SerializeField] private float levitationForce;

    public float LevitationForce
    {
        get => levitationForce;
        set => levitationForce = value;
    }

    [SerializeField] private float gravityForce;

    public float GravityForce
    {
        get => gravityForce;
        set => gravityForce = value;
    }

    [SerializeField] private float gravEffectTimer;

    public float GravEffectTimer
    {
        get => gravEffectTimer;
        set => gravEffectTimer = value;
    }

    [SerializeField] private float gravEffectDuration;

    public float GravEffectDuration
    {
        get => gravEffectDuration;
        set => gravEffectDuration = value;
    }

    private GameObject player;
    private GameObject exitDoor;
    private Slider oxygenSlider;
    private TextMeshProUGUI gravityText;
    private Animator gravTextAnimator;

    private void Start()
    {
        exitDoor = GameObject.Find("Exit");
        player = GameObject.FindGameObjectWithTag("Player");
        oxygenSlider = GameObject.Find("OxygenSlider").GetComponent<Slider>();
        gravityText = GameObject.Find("GravityText").GetComponent<TextMeshProUGUI>();
        gravTextAnimator = gravityText.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        oxygenSlider.value = player.GetComponent<PlayerController>().oxygenLevel;

        if (Input.GetButtonDown("Activate Gravity Nullifier") &&
            player.GetComponent<PlayerController>().Rb.velocity.magnitude <= 0.1)
            gravityNullified = true;
        
        if (gravityNullified)
        {
            gravTextAnimator.SetTrigger("ActivateGravText");
            GravEffectTimer += Time.deltaTime;
            if (GravEffectTimer >= GravEffectDuration)
            {
                GravityNullified = false;
                GravEffectTimer = 0;
            }
        }
        else
        {
            gravTextAnimator.SetTrigger("DeactivateGravText");
            gravTextAnimator.ResetTrigger("ActivateGravText");
        }
    }

    public void OpenExit()
    {
        Destroy(exitDoor);
    }
}
