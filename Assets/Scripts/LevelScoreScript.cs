using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the score a player receives after completing a level */
public class LevelScoreScript : MonoBehaviour
{

    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: Exchange with correct script (Time)
        timeLeft = 24;
        CalculateLevelScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /* Calculates a score according to how long the player needed to complete the level */
    void CalculateLevelScore(){
        int timeNeededInPercent = (int) ((timeLeft / 30) * 100);
        Debug.Log(timeNeededInPercent);

      if (timeNeededInPercent <= 100 && timeNeededInPercent >= 80)
      {
          Debug.Log("S RANK");
          EndScoreScript.Score += 5;
      }
      if (timeNeededInPercent <= 79 && timeNeededInPercent >= 50)
      {
          Debug.Log("A RANK");
          EndScoreScript.Score += 4;
      }
      if (timeNeededInPercent <= 49 && timeNeededInPercent >= 30)
      {
          Debug.Log("B RANK");
          EndScoreScript.Score += 3;
      }
      if (timeNeededInPercent <= 29 && timeNeededInPercent >= 10)
      {
          Debug.Log("C RANK");
          EndScoreScript.Score += 2;
      }
      if (timeNeededInPercent <= 9 && timeNeededInPercent >= 0)
      {
          Debug.Log("D RANK");
          EndScoreScript.Score += 1;
      }
    }
}
