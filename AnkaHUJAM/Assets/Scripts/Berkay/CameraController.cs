using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 dist;

    float rotationX;
    float rotationY;

    public float sensX;
    public float sensY;

    private Vector3 vel;

    public Transform orientation;

    private GameHandler gameHandler;

    void Start()
    {
        dist = transform.position - player.transform.position;
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();


        // Put the cursor in the middle of the 
        // screen lock and make it unvisible
        /*
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        */
    }

    void Update()
    {
        LookAroundWithMouse();
    }

    void LateUpdate()
    {
        FollowPlayer();
    }


    [ContextMenu(nameof(putCameraOnPlayer))]
    void putCameraOnPlayer()
    {
        transform.position = player.transform.position +
                             new Vector3(0, (player.transform.localScale.y / 2), 0);
    }

    void FollowPlayer()
    {
        //if (gameHandler.GravityNullified)
        //{
        transform.position = player.transform.position + dist;
            // if (!player.GetComponent<PlayerController>().isOnGround())
            //     transform.position = Vector3.SmoothDamp(transform.position, orientationTPS.position, ref vel, .5f);
            // else if (player.GetComponent<PlayerController>().isOnGround())
            //     transform.position = Vector3.SmoothDamp(transform.position, orientationFPS.position, ref vel, 0.01f);
        //}
    }

    void LookAroundWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        float vel = 0.125f;

        float newMouseX = Mathf.SmoothDamp(mouseX, -1, ref vel, 0.4f);
        float newMouseY = Mathf.SmoothDamp(mouseY, -1, ref vel, 0.4f);
        
        // Debug.Log("MouseX: " + mouseX + " MouseY: " + mouseY);

        rotationX -= newMouseY;
        rotationY += newMouseX;

        rotationX = Mathf.Clamp(rotationX, -45f, 45f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "triggerDoor")
        {
            Debug.Log("DoorTriggered");
        }
    }
}