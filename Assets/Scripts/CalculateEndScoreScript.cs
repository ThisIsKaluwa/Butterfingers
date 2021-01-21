using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* This script handles the score the player receives at the end of the game, based on all the individual scores a player got */
public class DisplayResultScript : MonoBehaviour
{
    private Label finalScoreLabel; //for displaying the Score on screen in game 

    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Score Label from the UIDocument with a Query
        finalScoreLabel = UIDocument.Q<Label>("ScoreCount");
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
            finalScoreLabel.text = "S RANK";
        }
        if (finalScore == 4)
        {
            finalScoreLabel.text = "A RANK";
        }
        if (finalScore == 3)
        {
            finalScoreLabel.text = "B RANK";
        }
        if (finalScore == 2)
        {
            finalScoreLabel.text = "C RANK";
        }
        if (finalScore == 1)
        {
            finalScoreLabel.text = "D RANK";
        }

    }
}
