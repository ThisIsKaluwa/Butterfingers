/* This Level handles the Menu at the start of the game 
The player can choose to either start the game or look at the tutorial */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    private static Button startButton; 
    private static Button tutorialButton;
    private static Button closeTutorialButton;
    private static VisualElement menuWrapper;
    private static VisualElement tutorialWrapper;
    private bool tutorialShown = false;

    //This function is called when the object becomes enabled and active.
    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;

        //Gets all the Menu Components by Query
        startButton = UIDocument.Q<Button>("start");
        tutorialButton = UIDocument.Q<Button>("tutorial");
        closeTutorialButton = UIDocument.Q<Button>("Close");
        menuWrapper = UIDocument.Q<VisualElement>("MenuWrapper");
        tutorialWrapper = UIDocument.Q<VisualElement>("TutorialWrapper");

        startButton.RegisterCallback<ClickEvent>(e => StartGame());
        tutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
        closeTutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
    }

    //Executed when the player presses "Start Game"
    void StartGame(){
        SceneManager.LoadScene(1);
        StoreLivesScript.lives = 3;
    }

    //Excuted when the player presses "Tutorial"
    void ToggleTutorial() {

        if (tutorialShown) {
            menuWrapper.style.display = DisplayStyle.Flex;
            tutorialWrapper.style.display = DisplayStyle.None;
            tutorialShown = false;
        } else {
            menuWrapper.style.display = DisplayStyle.None;
            tutorialWrapper.style.display = DisplayStyle.Flex;
            tutorialShown = true;
        }
    }
    
}
