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

    public Transform orientation;
    
    void Start()
    {
        dist = transform.position - player.transform.position;

        // Put the cursor in the middle of the 
        // screen lock and make it unvisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        transform.position = player.transform.position + dist;    
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

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

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
