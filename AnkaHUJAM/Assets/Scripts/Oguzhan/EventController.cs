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
        KeyPickup,
        FinishedGame,
        ExitDoorNoKeycard,
    }
    
    [SerializeField] private EventType eventType;
    private GameObject closeableDoor;
    private GameHandler gameHandler;
    private PlayerController playerController;
    
    private void Start()
    {
        gameHandler =  GameObject.Find("Game Handler").GetComponent<GameHandler>();
        closeableDoor = GameObject.Find("Closable");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(gameHandler.keycardFound && eventType == EventType.ExitDoorNoKeycard)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && eventType == EventType.DeathTrap)
        {
            gameHandler.PlayDeathClip();
            playerController.oxygenLevel = 0;
        }

        if (other.CompareTag("Player") && eventType == EventType.WeaponPickup)
        {
            gameHandler.weaponText.enabled = true;
            gameHandler.aPanelIsOpen = true;
            closeableDoor.GetComponent<Collider>().isTrigger = false;
            closeableDoor.GetComponent<MeshRenderer>().enabled = true;
            Camera.main.transform.Find("Gun").gameObject.SetActive(true);
            
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && eventType == EventType.KeyPickup)
        {
            gameHandler.OpenExit();
            gameHandler.aPanelIsOpen = true;
            gameHandler.keycardFound = true;
            gameHandler.keycardText.enabled = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && eventType == EventType.ExitDoorNoKeycard && !gameHandler.keycardFound)
        {
            gameHandler.exitDoorText.enabled = true;
            gameHandler.aPanelIsOpen = true;
        }
        
        if (other.CompareTag("Player") && eventType == EventType.FinishedGame && gameHandler.keycardFound)
        {
            gameHandler.finishPanel.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            gameHandler.aPanelIsOpen = true;
            Time.timeScale = 0;
        }
    }
}
