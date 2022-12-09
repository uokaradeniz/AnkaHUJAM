using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public enum EventType
    {
        DeathTrap,
        WeaponPickup,
        KeyPickup
    }

    [SerializeField] private EventType eventType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && eventType == EventType.DeathTrap)
        {
            Debug.Log("Event Triggered!");
        }

        if (other.CompareTag("Player") && eventType == EventType.WeaponPickup)
        {
            Debug.Log("Picked up Weapon!");
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && eventType == EventType.KeyPickup)
        {
            Debug.Log("Obtained the key, find the exit!");
            Destroy(gameObject);
        }
    }
}
