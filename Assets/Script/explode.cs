using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

    public float Delay = 1.5f;


	// Use this for initialization
	void Start () {
        Destroy(gameObject, Delay);
	}
	

    //Damage done to enemies and Player
    void OnTriggerEnter(Collider other)
    {
        //Damage done to brown monster
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyAI>().currentEnemyHealth--;
            if (other.gameObject.GetComponent<enemyAI>().currentEnemyHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        //Damage done to bat
        else if (other.gameObject.tag == "enemyBat")
        {
            Debug.Log("Bat hit");
            other.gameObject.GetComponent<AIBAt>().BatHealth--;
            if (other.gameObject.GetComponent<AIBAt>().BatHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        //Damage done to Player if invincible or not
        else if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();
        
            if (playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }
            else if (!playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().currentHealth--;
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }

            //Destroy the player object.
            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        //Damage done to the slime
        else if (other.gameObject.tag == "enemySlime")
        {
            other.gameObject.GetComponent<SlimeScript>().currentSlimeHealth--;
            if (other.gameObject.GetComponent<SlimeScript>().currentSlimeHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        //Damage done to barrel
        else if (other.gameObject.tag == "Barrel")
        {
            other.gameObject.GetComponent<barrelHealth>().reduceHealth();
            if (other.gameObject.GetComponent<barrelHealth>().health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        //Damage done to barrel2
        else if (other.gameObject.tag == "Barrel2")
        {
            other.gameObject.GetComponent<barrel2Health>().reduceHealth();
            if (other.gameObject.GetComponent<barrel2Health>().health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        //Damage done to crate
        else if (other.gameObject.tag == "Crate")
        {
            other.gameObject.GetComponent<CrateHealth>().reduceHealth();
            if (other.gameObject.GetComponent<CrateHealth>().health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
