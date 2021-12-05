using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGateScript : MonoBehaviour
{
    public AudioClip door_open;


    //open green gate if player has green key
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && Variables.greenKey > 0)
        {
            AudioSource.PlayClipAtPoint(door_open, transform.position);
            Variables.greenKey--;
            Destroy(gameObject);
        }
    }
}
