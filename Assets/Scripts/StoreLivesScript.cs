/** This script handles the tracking of the player lives thorughout the entire game, saving the current lives across scenes */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoreLivesScript
{
    public static int lives;
    public static int Life 
    {
        get 
        {
            return lives;
        }
        set 
        {
            lives = value;
        }
    }
}
