using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableGuide : MonoBehaviour
{
    public GameObject ArrowGuides;
    public float timeRemaining = 3;
    public bool timerIsRunning;


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
                Hit();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                endHit();
                resetTimer();
            }
        }
    }

    public void Hit()
    {
        ArrowGuides.SetActive(true);
    }

    public void endHit()
    {
        ArrowGuides.SetActive(false);
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
