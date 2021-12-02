using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPowerUp : MonoBehaviour
{

    //public AudioClip explode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("more health");
            //AudioSource.PlayClipAtPoint(explode, transform.position);
            other.GetComponent<PlayerMovement>().currentHealth++;
            gameObject.SetActive(false); //removes object.
        }
    }
}
