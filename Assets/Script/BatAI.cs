using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{

    Transform player; // Reference to the player's position.
    UnityEngine.AI.NavMeshAgent nav; // Reference to the nav mesh agent.
    public int batHealth;
    public int batDamage;


    //implementing FSM AI
    public enum States
    {
        patrol,
        chase
    }

    States _state = States.patrol;

    void patrol()
    {
        Vector3 go = transform.position + transform.forward * 10;
        Vector3 back = transform.position + transform.forward * -10;

        nav.SetDestination(go);
        nav.SetDestination(back);

    }


    void Chase() //chase player
    {
        if (batHealth > 0 && player)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }

    void ChangeStates()
    {

        float distance = 0;
        //calculate the distnce btw player and bat

        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }

        //if player is dead, stop chasing 
        else
        {
            _state = States.patrol; return;
        }

        if (distance < 4)
        { //player in the zone,
            if (batHealth > 0)
            {
                switch (_state)
                {
                    case States.patrol:
                        _state = States.chase;
                        break;
                    case States.chase:
                        break;
                }
            }
        }
        else
        { //player out the zone
            switch (_state)
            {
                case States.patrol:
                    break;
                case States.chase:
                    _state = States.patrol;
                    break;
            }
        }
    }


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        ChangeStates();

        switch (_state)
        {
            case States.patrol: patrol(); break;
            case States.chase: Chase(); break;
        }

        // If the enemy has health left...
        if (batHealth > 0 && player)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().currentHealth -= batDamage;
            other.gameObject.GetComponent<PlayerMovement>().Hit();
            other.gameObject.GetComponent<PlayerMovement>().timerHit();

            Debug.Log("Player Health = " + other.gameObject.GetComponent<PlayerMovement>().currentHealth);

            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }

        }

    }

}
