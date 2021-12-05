using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPit : MonoBehaviour
{
    
    //Damage done to Player if it enters lava pit 
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {   
            PlayerMovement playerScript = other.gameObject.GetComponent<PlayerMovement>();

            //check if is invincible (no damage)
            if (playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }
            //check if is invincible (damage)
            else if (!playerScript.isInvincible)
            {
                other.gameObject.GetComponent<PlayerMovement>().lavaDamage();
                other.gameObject.GetComponent<PlayerMovement>().Hit();
                other.gameObject.GetComponent<PlayerMovement>().timerHit();
            }

            //destroy Player object
            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
