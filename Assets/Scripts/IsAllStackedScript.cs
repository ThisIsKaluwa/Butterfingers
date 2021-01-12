using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles the tracking of every meal that is yet to stack and every meal that is stacked to determine if every meal is assembled */
public class IsAllStackedScript : MonoBehaviour
{


    public static int howManyThingsToStack;
    public static int howManyThingsAreStacked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (howManyThingsAreStacked == howManyThingsToStack)
        {

            //EverythingisStacked
        }
    }
}
