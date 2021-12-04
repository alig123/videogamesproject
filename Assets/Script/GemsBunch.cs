using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsBunch : MonoBehaviour
{

    //public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //player collects gems
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("collected gems");
            other.GetComponent<PlayerMovement>().gemsBunch();
            //AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            Destroy(gameObject);
        }
    }
}
