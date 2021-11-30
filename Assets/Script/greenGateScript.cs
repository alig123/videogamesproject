using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGateScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && Variables.greenKey > 0)
        {
            Variables.greenKey--;
            Destroy(gameObject);
        }
    }
}
