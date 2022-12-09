using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float jump_power = 5f;
    public float groundDrag;
    public LayerMask ground_layer;
    public Transform orientation;

    float horizontal;
    float vertical;

    private CapsuleCollider capsuleCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = transform.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        handleDrag();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        rb.AddForce(moveDirection.normalized * speed  * 10f, ForceMode.Force);

    }

    bool isOnGround()
    {
        float extra_height = 0.1f;
        bool ray_hit = Physics.Raycast(capsuleCollider.bounds.center,
                                       Vector3.down,
                                       capsuleCollider.bounds.extents.y + extra_height,
                                       ground_layer);

        return ray_hit;
    }

    void handleDrag()
    {
        if (isOnGround())
        {
            rb.drag = groundDrag;
        }
        else 
        {
            rb.drag = 0;
        }

    }
}
