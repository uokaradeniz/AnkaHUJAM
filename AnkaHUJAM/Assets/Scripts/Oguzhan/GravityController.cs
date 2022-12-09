using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private GameHandler gameHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameHandler.GravityNullified)
        {
            if (transform.position.y < gameHandler.MaxHeight)
            {
                Vector3 levitation = new Vector3(0,  gameHandler.LevitationForce, 0);
                rb.AddForce(levitation * Time.fixedDeltaTime, ForceMode.Impulse);
            }
            else
            {
                gameHandler.GravEffectTimer += Time.deltaTime;
                if (gameHandler.GravEffectTimer >= gameHandler.GravEffectDuration)
                {
                    gameHandler.GravityNullified = false;
                    gameHandler.GravEffectTimer = 0;
                }
            }
        }
        else
        {
            Vector3 gravity = new Vector3(0, -gameHandler.GravityForce, 0);
            rb.AddForce(gravity * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}