using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redGateScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && KeyVariables.redKey > 0)
        {
            KeyVariables.redKey--;
            Destroy(gameObject);
        }
    }
}
