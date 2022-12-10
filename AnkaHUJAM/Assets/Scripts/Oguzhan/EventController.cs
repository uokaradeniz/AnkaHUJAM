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
    private GameObject closeableDoor;

    private void Start()
    {
        closeableDoor = GameObject.Find("Closable");
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
            closeableDoor.GetComponent<Collider>().isTrigger = false;
            closeableDoor.GetComponent<MeshRenderer>().enabled = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && eventType == EventType.KeyPickup)
        {
            Debug.Log("Obtained the key, find the exit!");
            Destroy(gameObject);
        }
    }
}
