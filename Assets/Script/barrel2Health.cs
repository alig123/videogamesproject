using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel2Health : MonoBehaviour
{
    public float health = 1;

    public void reduceHealth()
    {
        //reduce health of crate
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
