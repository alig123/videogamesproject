using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPit : MonoBehaviour
{

    //public GameObject Player;
    //public bool inLava;
    //public int inLavaDamage = 1;
    public GameObject lava;
    public float timeRemaining = 3;
    public bool timerIsRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        
        timerIsRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                lavaOn();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                lavaOf();
                timeRemaining = 0;
                timerIsRunning = false;
                resetTimer();
            }
        }
    }
    
    public void lavaOn()
    {
        lava.SetActive(true);
    }

    public void lavaOf()
    {
        lava.SetActive(false);
    }

    public void resetTimer()
    {
        timerIsRunning = true;
        if (timerIsRunning == true)
        {
            lavaOf();
            timeRemaining = 3;
        }
    }

    /**
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Debug.Log("Player is in lava pit");
            other.gameObject.GetComponent<PlayerMovement>().lavaDamage();
            //other.gameObject.GetComponent<PlayerMovement>().timerHit();

        }
    }**/
    /**
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player is in lava pit");
            other.gameObject.GetComponent<PlayerMovement>().lavaDamage();
        }
    }**/



}
