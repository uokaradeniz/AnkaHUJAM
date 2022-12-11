using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private GameObject player;
    public float atkPower;
    
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);
        
        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            GetComponent<Animator>().SetBool("Attack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }
    }

    public void Attack()
    {
        player.GetComponent<PlayerController>().oxygenLevel -= atkPower;
    }
}
