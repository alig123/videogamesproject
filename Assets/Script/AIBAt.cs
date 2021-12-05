using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBAt : MonoBehaviour
{

    Transform player; // Reference to the player's position.
    UnityEngine.AI.NavMeshAgent agent; // Reference to the nav mesh agent.
    public int BatHealth = 1;
    public int BatDamage = 1;
    public GameObject Player;
    public bool follow = false;
    public AudioClip hitSound;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    //Damage done to Player if invincible or not
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();
            follow = true;
            if (playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().Hit(); //start bleed affect
                other.gameObject.GetComponent<PlayerMovement>().timerHit(); //start timer
            }
            else if (!playerScript.isInvincible)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                other.gameObject.GetComponent<PlayerMovement>().currentHealth--; //remove one health
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }

            //Destroy Player object
            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }

    //Follow the player is follow is set to true
    void Update()
    {
        if (follow == true)
        {
            agent.destination = Player.transform.position;
        }
    }
}
