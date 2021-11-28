using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public GameObject ArrowGuides;
    public GameObject Cheese;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().Cheese++;
            ArrowGuides.SetActive(true);
            Cheese.SetActive(false);
        }
    }
}
