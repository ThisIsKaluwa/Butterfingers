﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* This script handles the displaying of lives in the current level */
public class DisplayLifesScript : MonoBehaviour
{
    private VisualElement tomato1; 
    private VisualElement tomato2; 
    private VisualElement tomato3; 


    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the IMG Conatiner from the UI Document with a query
        tomato1 = UIDocument.Q<VisualElement>("Tomato1");
        tomato2 = UIDocument.Q<VisualElement>("Tomato2");
        tomato3 = UIDocument.Q<VisualElement>("Tomato3");
    }

    // Start is called before the first frame update
    public int howManyLives;
    void Start()
    {
        howManyLives = StoreLivesScript.lives;
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

            Debug.Log("Here");
            //display 3 lives
            tomato1.style.display = DisplayStyle.Flex;
            tomato2.style.display = DisplayStyle.Flex;
            tomato3.style.display = DisplayStyle.Flex;
        }

        if (howManyLives == 2)
        {
            //display 2 lives
            tomato3.style.display = DisplayStyle.None;
        }
        if (howManyLives == 1)
        {
            //display 1 lives
            tomato3.style.display = DisplayStyle.None;
            tomato2.style.display = DisplayStyle.None;
        }
        if (howManyLives == 0)
        {   
            //display 0 lives
            tomato3.style.display = DisplayStyle.None;
            tomato2.style.display = DisplayStyle.None;
            tomato1.style.display = DisplayStyle.None;
            NoMoreLives();
        }
    }

    void NoMoreLives()
    {
        //Display failure Screen and reset to main menu
    }
}