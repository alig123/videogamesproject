using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBomb2 : MonoBehaviour
{
    public GameObject CollectBomb;


    void Start()
    {
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().noBomb++;
            CollectBomb.SetActive(false);
        }
    }

    void Update()
    {
       //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
