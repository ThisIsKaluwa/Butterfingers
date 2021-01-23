using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* This script handles the countdown that the player sees before the actual level with all its tasks starts */
public class CountdownScript : MonoBehaviour
{
    private float timeRemaining = 5;
    private bool timerIsRunning = false;
    private Label timerLabel; //for displaying the seconds on screen in game 
    private VisualElement timerContainer;
    int howManyLives;

    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Timer Label from the UIDocument with a Query
        timerLabel = UIDocument.Q<Label>("StartCountDownLabel");
        timerContainer = UIDocument.Q<VisualElement>("CountDownWrapper");
    }

    private void Start()
    {
        // Starts the timer automatically if more than 0 lives
        howManyLives = StoreLivesScript.lives;
        if (howManyLives > 0 ) {
            timerIsRunning = true;
        } else {
            timerContainer.style.display = DisplayStyle.None;
        }
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
                DisplayString("Go!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerLabel.text = string.Format("{0:0}",seconds);
    }


    void DisplayString(string stringToDisplay)
    {
        timerLabel.text = stringToDisplay;
        Invoke("Run", 1.0f);
    }

    void Run() {
        timerContainer.style.display = DisplayStyle.None;
    }
}
