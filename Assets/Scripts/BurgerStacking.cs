using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles the correct way of stacking a burger 
The correct order (from bottom to top) is: bottom bun, patty, cucumber and a top bun
 */
public class BurgerStacking : MonoBehaviour
{

    public GameObject TopBun;

    public GameObject Cucumber;
    public GameObject Patty;
    public GameObject BottomBun;
    private bool isStacked = false;

    // Start is called before the first frame update
    void Start()
    {
        IsAllStackedScript.howManyThingsToStack++; //increment how many items need to be stacked in the entire scene by one

    }

    // Update is called once per frame
    void Update()
    {
        bool isTopBunUpright = checkIfTopBunUpright();
        bool topBunCorrect = isTopBunCorrect();
        bool pattyCorrect = isPattyCorrect();
        bool cucumberCorrect = isCucumberCorrect();


        if (isTopBunUpright && topBunCorrect && pattyCorrect && cucumberCorrect && !isStacked)
        {
            IsAllStackedScript.howManyThingsAreStacked++;
            TopBun.GetComponent<Rigidbody>().isKinematic = true;
            BottomBun.GetComponent<Rigidbody>().isKinematic = true;
            Patty.GetComponent<Rigidbody>().isKinematic = true;
            Cucumber.GetComponent<Rigidbody>().isKinematic = true;
            isStacked = true;

        }
    }


    /* Checks to see if the upper bun of the buger is upright
    @return true if the burger bun is upright (can be slightly tilted)
    @return false if the burger bun is flipped upside down
    */
    bool checkIfTopBunUpright()
    {
        if ((Vector3.Dot(TopBun.transform.up, Vector3.up)) <= 1.0f && (Vector3.Dot(TopBun.transform.up, Vector3.up)) >= 0.8f)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    /* Checks to see if the upper burger bun is correctly placed */
    bool isTopBunCorrect()
    {
        if (Vector3.Distance(TopBun.transform.position, Patty.transform.position) <= 0.13f)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    /* Checks to see if the burger patty is correctly placed */
    bool isPattyCorrect()
    {
        if (Vector3.Distance(Patty.transform.position, BottomBun.transform.position) <= 0.13f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    bool isCucumberCorrect(){
        if (Vector3.Distance(Patty.transform.position, Cucumber.transform.position) <= 0.1f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
