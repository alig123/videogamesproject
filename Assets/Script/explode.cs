using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {

    public float Delay = 1.5f;


	// Use this for initialization
	void Start () {
        Destroy(gameObject, Delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyAI>().currentEnemyHealth--;
            if (other.gameObject.GetComponent<enemyAI>().currentEnemyHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "enemyBat")
        {
            other.gameObject.GetComponent<ScriptBat>().batHealth--;
            if (other.gameObject.GetComponent<ScriptBat>().batHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().currentHealth--;
            if (other.gameObject.GetComponent<PlayerMovement>().currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        else if (other.gameObject.tag == "enemySlime")
        {
            other.gameObject.GetComponent<SlimeScript>().currentSlimeHealth--;
            if (other.gameObject.GetComponent<SlimeScript>().currentSlimeHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
