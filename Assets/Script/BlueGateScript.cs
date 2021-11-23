using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGateScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && KeyVariables.blueKey > 0) 
        {
            KeyVariables.blueKey--;
            Destroy(gameObject);
        }
    }
}
