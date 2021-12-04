using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableInvincible : MonoBehaviour
{
    public GameObject BananaInvincible;
    public float timeRemaining = 3;
    public bool timerIsRunning;
    public bool isInvincible;


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
                invinsibleOn();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                invinsibleOff();
                resetTimer();
            }
        }
    }

    public void invinsibleOn()
    {
        isInvincible = true;
    }

    public void invinsibleOff()
    {
        isInvincible = false;
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
            timeRemaining = 3;
        }
    }
}
