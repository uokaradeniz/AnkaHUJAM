using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{

    public LayerMask breakable;
    // public float maxDistanceForRay;

    GameObject player;

    void Start()
    {
        player = transform.parent.gameObject;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shots Fired!!!");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject muzzle = transform.GetChild(0).gameObject;
        RaycastHit ray_hit;
        if (Physics.Raycast(muzzle.transform.position, Vector3.forward, out ray_hit, Mathf.Infinity, breakable))
        {    
            Debug.Log("Wall shot.");
        }
    }
}
