using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponentInChildren<PlayerMovement>().speed++;
            gameObject.SetActive(false); //removes object.
        }
    }
}
