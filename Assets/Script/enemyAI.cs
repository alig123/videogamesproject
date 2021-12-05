using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyAI : MonoBehaviour { 

    Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public int currentEnemyHealth = 2;
    public GameObject explode;
    public AudioClip hitSound;


    //Damage done to player if invincible or not.
    private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();

            if (playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }
            else if (!playerScript.isInvincible)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                Instantiate(explode, transform.position, transform.rotation);
                other.gameObject.GetComponent<PlayerMovement>().brownDamage();
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
                gameObject.SetActive(false);
            }

            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
	}
}
