using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    private GameObject muzzle;
    private LineRenderer lineRenderer;
    private GameHandler gameHandler;
    private PlayerController playerController;

    private void Start()
    {
        lineRenderer = transform.Find("Line").GetComponent<LineRenderer>();
        muzzle = transform.Find("Muzzle").gameObject;
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isOnGround())
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(0, 0, 0);

        if (!gameHandler.GravityNullified)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                lineRenderer.enabled = true;
                GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Voce"));
                playerController.oxygenLevel -= 2;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit ray_hit;

        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out ray_hit, 15))
        {
            lineRenderer.SetPosition(0, muzzle.transform.position);
            lineRenderer.SetPosition(1, ray_hit.point);
            Invoke("CloseLineRenderer", 0.1f);
            if (ray_hit.collider.CompareTag("Breakable"))
            {
                Destroy(ray_hit.collider.gameObject);
                Instantiate(Resources.Load("WallBreakFX"), ray_hit.collider.transform.position,
                    ray_hit.collider.transform.rotation);
            }
            else if (ray_hit.collider.CompareTag("Enemy"))
            {
                ray_hit.collider.GetComponent<EnemyAI>().health -= 1;
            }
        }
    }

    void CloseLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}