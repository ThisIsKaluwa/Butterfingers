using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/* This script handles the score the player receives at the end of the game, based on all the individual scores a player got */
public class CalculateEndScoreScript : MonoBehaviour
{
    private Label finalScoreLabel; //for displaying the Score on screen in game 
    private Button backToStart;

    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Score Label from the UIDocument with a Query
        finalScoreLabel = UIDocument.Q<Label>("ScoreCount");
        backToStart = UIDocument.Q<Button>("BackToStart");

        backToStart.RegisterCallback<ClickEvent>(e => EndGame() );
    }

    int endScore;
    // Start is called before the first frame update
    void Start()
    {
        endScore = EndScoreScript.Score;
    }

    // Update is called once per frame
    void Update()
    {
    }


    //Calculates the final score a player receives according to all the level scores
    void CalculateEndScore()
    {
        int finalScore = endScore / 10;

        if (finalScore == 5)
        {
            finalScoreLabel.text = "S";
        }
        if (finalScore == 4)
        {
            finalScoreLabel.text = "A";
        }
        if (finalScore == 3)
        {
            finalScoreLabel.text = "B";
        }
        if (finalScore == 2)
        {
            finalScoreLabel.text = "C";
        }
        if (finalScore == 1)
        {
            finalScoreLabel.text = "D";
        }

    }

    void EndGame() {
        SceneManager.LoadScene("Level0");
    }
}
