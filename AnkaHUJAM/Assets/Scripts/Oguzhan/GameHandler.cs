using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Activate Gravity Nullifier") && player.GetComponent<PlayerController>().Rb.velocity.magnitude <= 0.1)
            gravityNullified = true;
    }
}
