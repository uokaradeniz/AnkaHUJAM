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
    //public float t;
    public LayerMask ground_layer;
    public Transform orientation;

    float horizontal;
    float vertical;

    private GameHandler gameHandler;

    private CapsuleCollider capsuleCollider;
    private Animator animator;

    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = transform.GetComponent<CapsuleCollider>();
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        

        // RotateByAD();
    }

    void FixedUpdate()
    {
        if (!isOnGround())
            animator.SetBool("Floating", true);
        else
            animator.SetBool("Floating", false);

        animator.SetFloat("IsWalking", rb.velocity.magnitude);

        if (isOnGround())
            Move();

        /*
        void RotateByAD()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            }
    
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            }
    
        }
        */
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DoorTrigger")
        {
            other.isTrigger = false;

            MeshRenderer mr = other.gameObject.GetComponent<MeshRenderer>();
            mr.enabled = true;
        }
    }
    
    void Move()
    {
        Vector3 moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Impulse);

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