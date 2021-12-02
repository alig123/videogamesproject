using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBomb : MonoBehaviour
{
    public GameObject BombImage;
    public int noBomb;


    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerMovement>().noBomb++;
            //BombImage.GetComponent<BombCount>().text = " " + noBomb;
            //selectedObject.transform.FindChild("BombCount").GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
