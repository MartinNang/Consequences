using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int wave = 1;
    // public bool gameStarted = false;
    private static bool gamePaused = false;
    public static int score = 0;
    public static bool destinityPhase = false;
    public static bool destinityChosen = false;
    public static bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pauseGame()
    {
        if (!gamePaused)
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
    }

    void unpauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
    }
    public void EndDestinyPhase()
    {
        Debug.Log("destinityPhase = false");
        destinityPhase = false;
    }
}
