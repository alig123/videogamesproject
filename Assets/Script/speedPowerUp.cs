using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class speedPowerUp : MonoBehaviour
{

    public bool isSpeed;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;


    void Update()
    {
        //call player movement script
        PlayerMovement playerScript = gameObject.GetComponent<PlayerMovement>();

        //timer from speed
        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                //call speed feature
                playerScript.speedOn();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                playerScript.speedOff();
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
