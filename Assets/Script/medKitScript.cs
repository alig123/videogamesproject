using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medKitScript : MonoBehaviour
{
    public GameObject medKit;
    public AudioClip pickUpSound;

    //Player picks up invincible item.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            other.GetComponent<PlayerMovement>().addMedKit();
            medKit.SetActive(false);
        }
    }
}
