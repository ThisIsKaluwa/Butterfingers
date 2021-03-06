/*** This script handles the correct way of stacking a cheese burger 
The correct order (from bottom to top) is: bottom bun, cheese, patty, cucumber and a top bun
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheeseBurgerStacking : MonoBehaviour
{

    public GameObject TopBun;

    public GameObject Cucumber;
    public GameObject Patty;
    public GameObject Cheese;
    public GameObject BottomBun;
    private bool isStacked = false;

    Renderer[] condiments;
    //// Start is called before the first frame update
    void Start()
    {
        GetComponent<IsAllStackedScript>().howManyThingsToStack++; ///increment how many items need to be stacked in the entire scene by one
        condiments = Patty.GetComponentsInChildren<Renderer>();
    }

    /// Update is called once per frame
    void Update()
    {
        bool isTopBunUpright = checkIfTopBunUpright();
        bool topBunCorrect = isTopBunCorrect();
        bool pattyCorrect = isPattyCorrect();
        bool cucumberCorrect = isCucumberCorrect();
        bool cheeseCorrect = isCheeseCorrect();
        bool condimentsCorrect = areCondimentsCorrect();


        if (isTopBunUpright && topBunCorrect && pattyCorrect && cucumberCorrect && cheeseCorrect && condimentsCorrect && !isStacked)
        {
            GetComponent<IsAllStackedScript>().howManyThingsAreStacked++;
            TopBun.GetComponent<Rigidbody>().isKinematic = true;
            BottomBun.GetComponent<Rigidbody>().isKinematic = true;
            Patty.GetComponent<Rigidbody>().isKinematic = true;
            Cucumber.GetComponent<Rigidbody>().isKinematic = true;
            isStacked = true;
        }
    }


    /** Checks if the upper bun of the buger is upright
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

    /** Checks if the upper burger bun is correctly placed */
    bool isTopBunCorrect()
    {
        if (Vector3.Distance(TopBun.transform.position, Patty.transform.position) <= 0.1f)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    /** Checks if the burger patty is correctly placed */
    bool isPattyCorrect()
    {
        if (Vector3.Distance(Patty.transform.position, Cheese.transform.position) <= 0.13f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    /** Checks if the cucumber is correctly placed */
    bool isCucumberCorrect()
    {
        if (Vector3.Distance(Patty.transform.position, Cucumber.transform.position) <= 0.1f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    /** Checks if the cheese is correctly placed */
    bool isCheeseCorrect()
    {
        if (Vector3.Distance(BottomBun.transform.position, Cheese.transform.position) <= 0.13f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    /** Checks if mustard and ketchup are spawned, must both be on the same side */
    bool areCondimentsCorrect()
    {
        if (condiments[1].enabled && condiments[2].enabled || condiments[3].enabled && condiments[4].enabled)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
