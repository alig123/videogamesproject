using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour {

    float removeTime = 3.0f;
    public GameObject explode;
    public AudioClip ExplosionSound;
    public AudioClip BombCharge;
    

	// Use this for initialization
	void Start () {
        AudioSource.PlayClipAtPoint(BombCharge, transform.position);
        Destroy(gameObject, removeTime); 


	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale += new Vector3(0.08F, 0.08F, 0.08F);
        		
	}


    void OnDestroy() {       
        Instantiate (explode, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(ExplosionSound, transform.position);
    }



}
