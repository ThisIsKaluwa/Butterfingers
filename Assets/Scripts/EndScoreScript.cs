using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script is for handeling the score, saving it across scenes*/
public static class EndScoreScript
{
    private static int score;
    public static int Score 
    {
        get 
        {
            return score;
        }
        set 
        {
            score = value;
        }
    }

}
