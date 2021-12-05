using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerPowerUp : MonoBehaviour
{

    public AudioClip eatSound;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("more health");
            AudioSource.PlayClipAtPoint(eatSound, transform.position);
            other.GetComponent<PlayerMovement>().burgerHeal();
            gameObject.SetActive(false); //removes object.
        }
    }
}
