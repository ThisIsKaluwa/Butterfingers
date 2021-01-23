using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the tracking of every existing glass and every filled glass in the current scene to determine if every glass is filled */
public class AllGlassesFilledScript : MonoBehaviour
{

    public  int everyGlassToFill;
    public  int everyFilledGlass;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (everyGlassToFill == everyFilledGlass)
        {
            GetComponent<IsTheLevelFinishedScript>().allDrinksReady = true;
        }
    }
}
