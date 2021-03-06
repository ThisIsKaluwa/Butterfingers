﻿/** This script handles the pausing of the game when the player hits "ESC" and how the pause menu functions */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    private static Button retryButton;
    private static Button tutorialButton;
    private static Button endGameButton;
    private static Button closeButton;
    private static Button closeTutorialButton;
    private static VisualElement menuWrapper;
    private static VisualElement tutorialWrapper;
    private static VisualElement menuContainer;
    private bool tutorialShown = false;
    private bool isPaused = false;

    ///This function is called when the object becomes enabled and active.
    private void OnEnable() {
        ///Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;

        ///Gets all the Menu Components by Query
        retryButton = UIDocument.Q<Button>("retry");
        tutorialButton = UIDocument.Q<Button>("tutorial");
        closeTutorialButton = UIDocument.Q<Button>("CloseTutorial");
        closeButton = UIDocument.Q<Button>("Close");
        endGameButton = UIDocument.Q<Button>("end");
        menuWrapper = UIDocument.Q<VisualElement>("MenuWrapper");
        menuContainer = UIDocument.Q<VisualElement>("MenuContainer");
        tutorialWrapper = UIDocument.Q<VisualElement>("TutorialWrapper");


        tutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
        closeTutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
        closeButton.RegisterCallback<ClickEvent>(e => CloseMenu() );
        retryButton.RegisterCallback<ClickEvent>(e => Retry() );
        endGameButton.RegisterCallback<ClickEvent>(e => EndGame() );
    }


    /// Start is called before the first frame update
    void Start()
    {
        menuContainer.style.display = DisplayStyle.None;
    }

    /// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused) {
                CloseMenu();
            } else {
                Pause();
            }

        }
    }

    ///When the player hits pause the timer stops
    void Pause() { 
        menuContainer.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
        isPaused = true;
    }

    ///end the game and brings the player back to the start menu
    void EndGame() {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level0");
    }

    ///shows and hides the tutorial
    void ToggleTutorial() {
        if (tutorialShown) {
            tutorialWrapper.style.display = DisplayStyle.None;
            menuWrapper.style.display = DisplayStyle.Flex;
            tutorialShown = false;
        } else {
            menuWrapper.style.display = DisplayStyle.None;
            tutorialWrapper.style.display = DisplayStyle.Flex;
            tutorialShown = true;
        }
    }

    ///closes the menu and brings the player back to the level, the timer runs again
    void CloseMenu(){
        menuContainer.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        isPaused = false;
    }

    ///reloads the same level again 
    void Retry(){
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        menuContainer.style.display = DisplayStyle.None;
        isPaused = false;
        Time.timeScale = 1f;
        LevelTimerScript.timerIsRunning = false;
    }
}
