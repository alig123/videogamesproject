using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleCollect : MonoBehaviour
{
   
    public GameObject BananaInvincible;
    //public AudioClip pickUpSound;

    //Player picks up invincible item.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            other.GetComponent<PlayerMovement>().addInvincible();
            BananaInvincible.SetActive(false);
        }
    }
}
