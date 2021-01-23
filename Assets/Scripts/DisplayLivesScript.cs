using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/* This script handles the displaying of lives in the current level */
public class DisplayLivesScript : MonoBehaviour
{
    private VisualElement tomato1;
    private VisualElement tomato2;
    private VisualElement tomato3;

    //This function is called when the object becomes enabled and active.
    private void OnEnable()
    {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;
        //Gets the IMG Conatiner from the UI Document with a query
        tomato1 = UIDocument.Q<VisualElement>("Tomato1");
        tomato2 = UIDocument.Q<VisualElement>("Tomato2");
        tomato3 = UIDocument.Q<VisualElement>("Tomato3");
    }


    int howManyLives;

    // Start is called before the first frame update
    void Start()
    {
        howManyLives = StoreLivesScript.lives;
        Debug.Log(howManyLives);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 0.05f)
        {
            DisplayLives();
        }

    }

    //Displays the correct amount of tomatoes
    void DisplayLives()
    {
        if (howManyLives == 3)
        {
            //display 3 lives
            tomato1.style.display = DisplayStyle.Flex;
            tomato2.style.display = DisplayStyle.Flex;
            tomato3.style.display = DisplayStyle.Flex;
        }

        if (howManyLives == 2)
        {
            //display 2 lives
            tomato3.style.display = DisplayStyle.None;
            tomato1.style.display = DisplayStyle.Flex;
            tomato2.style.display = DisplayStyle.Flex;
        }
        if (howManyLives == 1)
        {
            //display 1 lives
            tomato3.style.display = DisplayStyle.None;
            tomato2.style.display = DisplayStyle.None;
            tomato1.style.display = DisplayStyle.Flex;
        }
        if (howManyLives == 0)
        {
            GameOver();
            tomato3.style.display = DisplayStyle.None;
            tomato2.style.display = DisplayStyle.None;
            tomato1.style.display = DisplayStyle.None;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
