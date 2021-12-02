using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenKeyScript : MonoBehaviour
{
    
    private int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //rotation speed
        rotateSpeed = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Variables.greenKey++;
            //AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.Self); //rotate the gameobject in local space
    }
}
