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
    private GameHandler gameHandler;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameHandler.gameFinished)
        {
            if (player.GetComponent<PlayerController>().oxygenLevel > 0)
            {
                if (health <= 0)
                {
                    Instantiate(Resources.Load("EnemyHitFX"), transform.position,
                        transform.rotation);
                    navMesh.Warp(gameHandler.spawnPos.position);
                    transform.position = gameHandler.spawnPos.position;
                    GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("MonsterDeath"));
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    health = 5;
                }
                else
                {
                    navMesh.SetDestination(player.transform.position);
                }

                if (gameHandler.GravityNullified)
                    navMesh.isStopped = true;
                else
                    navMesh.isStopped = false;


                if (navMesh.speed >= 10 && !gameHandler.GravityNullified)
                    GetComponent<Animator>().SetFloat("Walk", 1);
                else if (navMesh.speed < 10 || gameHandler.GravityNullified)
                    GetComponent<Animator>().SetFloat("Walk", 0);

                if (Vector3.Distance(player.transform.position, transform.position) < 4.5 &&
                    !gameHandler.GravityNullified)
                {
                    navMesh.speed = 3.5f;
                    GetComponent<Animator>().SetBool("Attack", true);
                }
                else
                {
                    navMesh.speed = 10;
                    GetComponent<Animator>().SetBool("Attack", false);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("Attack", false);
                navMesh.isStopped = true;
            }
        }
    }

    public void Attack()
    {
        player.GetComponent<PlayerController>().oxygenLevel -= atkPower;
        GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("MonsterAttack"));
    }
}