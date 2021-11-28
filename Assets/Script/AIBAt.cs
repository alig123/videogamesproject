using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBAt : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.- used later
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent agent;              // Reference to the nav mesh agent.
    public int BatHealth = 1;
    public int BatDamage = 1;
    public GameObject Player;
    public bool follow = false;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Player")
        {
            follow = true;
            other.gameObject.GetComponent<PlayerMovement>().currentHealth--;
            other.gameObject.GetComponent<PlayerMovement>().Hit();
            other.gameObject.GetComponent<PlayerMovement>().timerHit();



            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

    /**
    void Chase()
    {   
        nav.enabled = true;
        nav.SetDestination(player.position);     
    }**/

    void Update()
    {
        if (follow == true)
        {
            agent.destination = Player.transform.position;
        }
    }
}
