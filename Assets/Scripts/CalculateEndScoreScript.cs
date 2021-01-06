using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the score the player receives at the end of the game, based on all the individual scores a player got */
public class DisplayResultScript : MonoBehaviour
{

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
            Debug.Log("S RANK");
        }
        if (finalScore == 4)
        {
            Debug.Log("A RANK");
        }
        if (finalScore == 3)
        {
            Debug.Log("B RANK");
        }
        if (finalScore == 2)
        {
            Debug.Log("C RANK");
        }
        if (finalScore == 1)
        {
            Debug.Log("D RANK");
        }

    }
}
