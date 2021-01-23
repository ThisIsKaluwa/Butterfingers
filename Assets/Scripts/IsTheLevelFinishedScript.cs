using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IsTheLevelFinishedScript : MonoBehaviour
{

    public  bool allDrinksReady;
    public  bool allMealsReady;
    public  int timeLevelWasFinishedWith;
    private  static VisualElement scoreWindow; 
    private  static VisualElement endWindow; 

    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Score Label from the UIDocument with a Query
        scoreWindow = UIDocument.Q<VisualElement>("ScoreContainer");
        endWindow = UIDocument.Q<VisualElement>("ScoreContainer");
    }


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

        scoreWindow.style.display = DisplayStyle.Flex;

        Invoke("LoadTheNextLevel", 3.0f);

    }

    void LoadTheNextLevel(){
        int scene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = scene +1;

        if (nextScene == 11)
        {
            //game is done
            scoreWindow.style.display = DisplayStyle.None;
            endWindow.style.display = DisplayStyle.Flex;
        }
        else
        {
             SceneManager.LoadScene(nextScene);
             scoreWindow.style.display = DisplayStyle.None;
        }
       
    }
    
}
