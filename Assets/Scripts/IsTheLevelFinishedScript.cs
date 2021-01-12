using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTheLevelFinishedScript : MonoBehaviour
{

    public static bool allDrinksReady;
    public static bool allMealsReady;
    // Start is called before the first frame update
    void Start()
    {
        allDrinksReady = false;
        allMealsReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (allDrinksReady && allMealsReady)
        {
            
        }
    }
}
