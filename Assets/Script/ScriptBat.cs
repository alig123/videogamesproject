using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBat : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.- used later
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    public int currentEnemyHealth = 1;


    //implementing FSM AI
    public enum States
    {
        idle,
        chase,
        escape
    }

    States _state = States.idle;

    void Idling()
    {  //just stay put
        nav.enabled = false;
    }


    void Chase() //chase player
    {

        if (currentEnemyHealth > 0 && player)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }


    void Escape()
    {

        if (player)
        {
            nav.enabled = true;


            // turn away from the player 
            transform.rotation = Quaternion.LookRotation(transform.position - player.position);
            Vector3 runTo = transform.position + transform.forward * 10;
            nav.SetDestination(runTo);
        }
        else
        {
            nav.enabled = false;
        }


    }

    void ChangeStates()
    {

        float distance = 0;
        //calculate the distnce btw player and ghost

        if (player)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
        }

        //if player is dead, stop chasing 
        else
        {
            _state = States.idle; return;
        }


        if (distance < 4)
        { //player in the zone,
            if (currentEnemyHealth <= 1)
            { // low health, escape! 
                switch (_state)
                {
                    case States.idle:
                        _state = States.escape;
                        break;
                    case States.chase:
                        _state = States.escape;
                        break;
                    case States.escape:
                        break;
                }


            }
            else
            {
                switch (_state)
                {
                    case States.idle:
                        _state = States.chase;
                        break;
                    case States.chase:
                        break;
                    case States.escape:
                        break;
                }
            }

        }
        else
        { //player out the zone
            switch (_state)
            {
                case States.idle:
                    break;
                case States.chase:
                    _state = States.idle;
                    break;
                case States.escape:
                    _state = States.idle;
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
            case States.idle: Idling(); break;
            case States.chase: Chase(); break;
            case States.escape: Escape(); break;
        }

        // If the enemy has health left...
        if (currentEnemyHealth > 0 && player)
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
            other.gameObject.GetComponent<PlayerMovement>().currentHealth--;

            Debug.Log("Player Health = " + other.gameObject.GetComponent<PlayerMovement>().currentHealth);

            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
