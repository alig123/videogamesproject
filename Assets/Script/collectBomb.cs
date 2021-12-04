using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBomb : MonoBehaviour
{
    //public AudioClip pickUpSound;
    void Start()
    {

    }

    //Player picks up 1 bomb.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().noBomb++;
            //AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            gameObject.SetActive(false);
        }
    } 
}
