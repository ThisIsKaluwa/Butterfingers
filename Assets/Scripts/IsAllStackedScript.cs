using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsAllStackedScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int howManyThingsToStack;
    public static int howManyThingsAreStacked; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(howManyThingsAreStacked == howManyThingsToStack){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
