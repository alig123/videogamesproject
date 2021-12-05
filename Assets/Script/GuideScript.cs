using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public GameObject ArrowGuides;
    public GameObject Cheese;
    public AudioClip eatCheeseSound;


    //display arrow guides if player eats cheese
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            AudioSource.PlayClipAtPoint(eatCheeseSound, transform.position);
            other.GetComponent<PlayerMovement>().Cheese++;
            ArrowGuides.SetActive(true);
            Cheese.SetActive(false);
        }
    }
}

