using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTimer = 30;
    private float timeRemaining;
    public bool timerIsRunning = false;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        timeRemaining = maxTimer;
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

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
        textMeshProUGUI.text = timeRemaining.ToString("0");
    }

}