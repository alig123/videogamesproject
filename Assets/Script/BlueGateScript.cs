using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGateScript : MonoBehaviour
{
    public AudioClip door_open;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && Variables.blueKey > 0) 
        {
            AudioSource.PlayClipAtPoint(door_open, transform.position);
            Variables.blueKey--;
            Destroy(gameObject);
        }
    }
}
