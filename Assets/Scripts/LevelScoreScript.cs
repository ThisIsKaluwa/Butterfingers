using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* This script handles the score a player receives after completing a level 
This Script relies on a timer being used to meassure how sucessful the player is
*/
public class LevelScoreScript : MonoBehaviour
{
    public static float timeLeft;
    private static Label scoreLabel; //for displaying the Score on screen in game 

    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the Score Label from the UIDocument with a Query
        scoreLabel = UIDocument.Q<Label>("ScoreCountLabel");
    }

    /* Calculates a score according to how long the player needed to complete the level */
    public static void CalculateLevelScore(){
        int timeNeededInPercent = (int) ((timeLeft / 40) * 100);

      if (timeNeededInPercent <= 100 && timeNeededInPercent >= 80)
      {
          scoreLabel.text = "S RANK";
          EndScoreScript.Score += 5;
      }
      if (timeNeededInPercent <= 79 && timeNeededInPercent >= 50)
      {
          scoreLabel.text = "A RANK";
          EndScoreScript.Score += 4;
      }
      if (timeNeededInPercent <= 49 && timeNeededInPercent >= 30)
      {
          scoreLabel.text = "B RANK";
          EndScoreScript.Score += 3;
      }
      if (timeNeededInPercent <= 29 && timeNeededInPercent >= 10)
      {
          scoreLabel.text = "C RANK";
          EndScoreScript.Score += 2;
      }
      if (timeNeededInPercent <= 9 && timeNeededInPercent >= 0)
      {
          scoreLabel.text = "D RANK";
          EndScoreScript.Score += 1;
      }
    }
}
