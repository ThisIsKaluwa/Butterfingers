using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsTheLevelFinishedScript : MonoBehaviour
{

    public static bool allDrinksReady;
    public static bool allMealsReady;
    public static int timeLevelWasFinishedWith;

    // Start is called before the first frame update
    void Start()
    {
        allDrinksReady = false;
        allMealsReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (allDrinksReady && allMealsReady)
        {
            WrapUpTheLevel();
        }
    }

    void WrapUpTheLevel(){

        Debug.Log("Level finsihed");

        timeLevelWasFinishedWith = (int) LevelTimerScript.timeRemaining;
        LevelTimerScript.timerIsRunning = false;

        LevelScoreScript.timeLeft = timeLevelWasFinishedWith;

        LevelScoreScript.CalculateLevelScore();

        Invoke("LoadTheNextLevel", 3.0f);

    }

    void LoadTheNextLevel(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene +1;

        if (nextScene == 10)
        {
            //game is done
        }
        else
        {
             SceneManager.LoadScene(nextScene);
        }
       
    }
    
}
