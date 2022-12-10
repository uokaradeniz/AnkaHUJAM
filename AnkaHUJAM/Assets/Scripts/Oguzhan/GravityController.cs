using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private GameHandler gameHandler;
    private Vector3 vel = Vector3.zero;
    public float smoothFactor;
    
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
            if(!gameObject.CompareTag("Player"))
                rb.AddTorque(Vector3.one * Random.Range(-.1f ,.1f));
            //else
                //transform.Find("character").localScale = new Vector3(1, 1, 1);

                rb.useGravity = false;
            if (transform.position.y < gameHandler.MaxHeight)
            {
                /*
                Vector3 targetPos = new Vector3(transform.position.x, gameHandler.MaxHeight, transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothFactor);
                */
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
            //if(gameObject.CompareTag("Player"))
              //  transform.Find("character").localScale = new Vector3(0, 0, 0);
            
            rb.useGravity = true;
        }
    }
}