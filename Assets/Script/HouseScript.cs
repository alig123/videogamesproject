using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public GameManager gameManager;
    

    //if collected gems and reaches house, end game.
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            gameManager.CompleteLevel();
        }
    }
}
