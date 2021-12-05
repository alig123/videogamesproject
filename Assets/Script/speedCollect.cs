using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class speedCollect : MonoBehaviour
{
    public GameObject HotDogSpeed;
    public AudioClip pickUpSound;

    //Player picks up speed item.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            other.GetComponent<PlayerMovement>().addSpeed();
            HotDogSpeed.SetActive(false);
        }
    }
}