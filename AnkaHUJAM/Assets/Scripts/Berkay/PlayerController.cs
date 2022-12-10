using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb
    {
        get => rb;
        set => rb = value;
    }

    public float speed;
    public float RotateSpeed;
    public LayerMask ground_layer;
    public Transform orientation;
    private Transform cameraRotation;

    private float doorTimer;
    
    float horizontal;
    float vertical;
    
    private CapsuleCollider capsuleCollider;
    private Animator animator;

    public float oxygenLevel = 100;
    public float oxygenDepleteRate;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = transform.GetComponent<CapsuleCollider>();
        cameraRotation = Camera.main.transform;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        oxygenLevel -= oxygenDepleteRate * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (oxygenLevel > 0)
        {
            if (!isOnGround())
                animator.SetBool("Floating", true);
            else
                animator.SetBool("Floating", false);

            animator.SetFloat("IsWalking", rb.velocity.magnitude);

            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y = cameraRotation.rotation.y * 100;
            transform.rotation = Quaternion.Euler(rotationVector.x, rotationVector.y, rotationVector.z);

            if (isOnGround())
                Move();
        }
        else
        {
            Debug.Log("Wasted!");
        }

    }
    
    void Move()
    {
        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        rb.velocity = moveDirection.normalized * speed * Time.fixedDeltaTime;
        
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, RotateSpeed * Time.deltaTime);
        }
    }
    
    public bool isOnGround()
    {
        float extra_height = 0.1f;
        bool ray_hit = Physics.Raycast(capsuleCollider.bounds.center,
            Vector3.down,
            capsuleCollider.bounds.extents.y + extra_height,
            ground_layer);

        return ray_hit;
    }
}