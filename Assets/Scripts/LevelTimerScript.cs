using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This script handles the countdown that the player sees while they are playing a level */
public class LevelTimerScript : MonoBehaviour
{
    public static float timeRemaining = 40;
    public static bool timerIsRunning = false;

    public Text timeText; //for displaying the seconds on screen in game

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    //Update is called once per frame 
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:0}",seconds);
    }

}
