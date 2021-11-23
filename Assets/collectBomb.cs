using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBomb : MonoBehaviour
{
    //public AnimationCurve myCurve;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().noBomb++;
            //AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
       //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
