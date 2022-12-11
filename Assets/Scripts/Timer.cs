using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTimer;
    private float timeRemaining;
    public bool timerIsRunning = true;
    private TextMeshProUGUI textMeshProUGUI;
    public CardManager cardManager;

    private void Start()
    {
        timeRemaining = maxTimer;
        timerIsRunning = true;
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            if (timerIsRunning)
            {
                GameManager.pauseGame();
                timerIsRunning = false;              
                GameManager.destinityPhase = true;
                Debug.Log("Destiny Phase: On");
                cardManager.showRandomCards();
            }            
         
            if (GameManager.destinityChosen)
            {
                GameManager.destinityChosen = false;
                GameManager.wave++;
                GameManager.unpauseGame();
                timerIsRunning = true;
                timeRemaining = maxTimer;

            }
        }
        textMeshProUGUI.text = timeRemaining.ToString("0");
    }

}