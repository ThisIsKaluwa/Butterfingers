using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the displaying of lives in the current level */
public class DisplayLivesScript : MonoBehaviour
{
    // Start is called before the first frame update

    int howManyLives;
    void Start()
    {
        howManyLives = StoreLivesScript.Life;
        DisplayLives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayLives()
    {
        if (howManyLives == 3)
        {
            //display 3 lives
        }

        if (howManyLives == 2)
        {
            //display 2 lives
        }
        if (howManyLives == 1)
        {
            //display 1 lives
        }
        if (howManyLives == 0)
        {
            NoMoreLives();
        }
    }

    void NoMoreLives()
    {
        //Display failure Screen and reset to main menu
    }
}
