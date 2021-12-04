using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleScript : MonoBehaviour
{ 
    
    public bool isInvincible;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;


    void Update()
    {
        //call player movement script
        PlayerMovement playerScript = gameObject.GetComponent<PlayerMovement>();

        //timer from invincibility
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                //call invincible feature
                playerScript.invincibleOn();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                playerScript.invincibleOff();
                resetTimer();
            }
        }
    }

    public void timerHit()
    {
        timerIsRunning = true;
    }

    public void resetTimer()
    {
        timerIsRunning = false;
        if (timerIsRunning == false)
        {
            timeRemaining = 10;
        }
    }
}
