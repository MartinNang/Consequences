using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public static float maxTimer = 30;
    private static float timeRemaining = maxTimer;
    public static bool timerIsRunning = false;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining == 0)
        {
            if (timerIsRunning)
            {
                timerIsRunning = false;              
                GameManager.destinityPhase = true;
            }            
         
            if (GameManager.destinityChosen)
            {
                GameManager.wave++;
                timerIsRunning = true;
                timeRemaining = maxTimer;

            }
        }
    }

}