using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    public int currentSlimeHealth = 3;
    public int slimeDamage = 3;
    public int slimeSlowDamage = 2;
    

    //Damage done to player if invincible or not.
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //call script in Player
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();

            if (playerScript.isInvincible)
            {   
                //bleed effect timer
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }
            else if (!playerScript.isInvincible)
            {
                //damage and bleed effect timer
                other.gameObject.GetComponent<PlayerMovement>().SlimeAttack();
                other.gameObject.GetComponent<PlayerMovement>().currentHealth -= slimeDamage;
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }

            //destroy player object is health is 0
            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
