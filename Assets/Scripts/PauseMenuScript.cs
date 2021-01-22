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


    private void OnEnable() {
        //Gets the UI Document
        var UIDocument = GetComponent<UIDocument>().rootVisualElement;

        //Gets all the Menu Components by Query
        retryButton = UIDocument.Q<Button>("retry");
        tutorialButton = UIDocument.Q<Button>("tutorial");
        closeTutorialButton = UIDocument.Q<Button>("CloseTutorial");
        closeButton = UIDocument.Q<Button>("Close");
        endGameButton = UIDocument.Q<Button>("end");
        menuWrapper = UIDocument.Q<Button>("MenuWrapper");
        tutorialWrapper = UIDocument.Q<Button>("MenuContainer");
        menuContainer = UIDocument.Q<Button>("TutorialWrapper");


        tutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
        closeTutorialButton.RegisterCallback<ClickEvent>(e => ToggleTutorial());
        closeButton.RegisterCallback<ClickEvent>(e => CloseMenu() );
        retryButton.RegisterCallback<ClickEvent>(e => Retry() );
        endGameButton.RegisterCallback<ClickEvent>(e => EndGame() );
    }

    void EndGame(){
        SceneManager.LoadScene(0);
    }

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

    void CloseMenu(){
        menuContainer.style.display = DisplayStyle.None;
    }


    void Retry(){
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        menuContainer.style.display = DisplayStyle.None;
    }
}
