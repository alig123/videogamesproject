using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGateScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && KeyVariables.greenKey > 0)
        {
            KeyVariables.greenKey--;
            Destroy(gameObject);
        }
    }
}
