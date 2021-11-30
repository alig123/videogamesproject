using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGateScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && Variables.blueKey > 0) 
        {
            Variables.blueKey--;
            Destroy(gameObject);
        }
    }
}
