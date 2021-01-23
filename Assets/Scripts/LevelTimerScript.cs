using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/* This script handles the countdown that the player sees while they are playing a level */
public class LevelTimerScript : MonoBehaviour
{
    public static float timeRemaining;
    public static bool timerIsRunning = false;

    private Label timerLabel; //for displaying the seconds on screen in game 

    private void OnEnable()
    {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Timer Label from the UIDocument with a Query
        timerLabel = UIDocument.Q<Label>("CountDownLabel");
    }

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeRemaining = 10;
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
                StoreLivesScript.lives -= 1;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    //Converts the remaining float time to a minute:seconds String
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        //Calculates and stores the timer value in sec
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //Sets the timer value to the label
        timerLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
