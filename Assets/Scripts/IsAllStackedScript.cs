/** This script handles the tracking of every meal that is yet to stack and every meal that is stacked to determine if every meal is assembled */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsAllStackedScript : MonoBehaviour
{


    public  int howManyThingsToStack;
    public  int howManyThingsAreStacked;

    /// Start is called before the first frame update
    void Start()
    {

    }

    /// Update is called once per frame
    void Update()
    {
        if (howManyThingsAreStacked == howManyThingsToStack)
        {
            GetComponent<IsTheLevelFinishedScript>().allMealsReady = true;
        }
    }
}
