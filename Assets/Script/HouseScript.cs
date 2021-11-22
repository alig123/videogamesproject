using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && score = 4)
        {
            gameManager.CompleteLevel();
        }
    }
}
