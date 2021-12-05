using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    //teleport back to target if player collides
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}
