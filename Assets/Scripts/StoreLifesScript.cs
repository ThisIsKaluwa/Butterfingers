using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the tracking of the player lives thorughout the entire game, saving the current lives across scenes */
public static class StoreLifesScript
{
    public static int lifes;
    public static int Life 
    {
        get 
        {
            return lifes;
        }
        set 
        {
            lifes = value;
        }
    }
}
