using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    //public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Player picks up gem.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().gems++;
            //AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }

}
