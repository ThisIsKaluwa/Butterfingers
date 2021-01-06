using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles the correct way of stacking a burger 
The correct order (from bottom to top) is: lower bun, ketchup, patty, mustard and a top bun
 */
public class BurgerStacking : MonoBehaviour
{

    public GameObject TopBun;
    public GameObject Patty;
    public GameObject LowerBun;
    private bool isStacked = false;

    // Start is called before the first frame update
    void Start()
    {
        IsAllStackedScript.howManyThingsToStack++; //increment how many items need to be stacked in the entire scene by one

    }

    // Update is called once per frame
    void Update()
    {
        bool isBunUpright = checkIfBunUpright();
        bool lowerBunCorrect = isLowerBunCorrect();
        bool TopBunCorrect = isTopBunCorrect();
        bool pattyCorrect = isPattyCorrect();


        if (isBunUpright && lowerBunCorrect && TopBunCorrect && pattyCorrect && !isStacked)
        {
            IsAllStackedScript.howManyThingsAreStacked++;
            TopBun.GetComponent<Rigidbody>().isKinematic = true;
            LowerBun.GetComponent<Rigidbody>().isKinematic = true;
            Patty.GetComponent<Rigidbody>().isKinematic = true;

            isStacked = true;
        }
    }


    /* Checks to see if the upper bun of the buger is upright
    @return true if the burger bun is upright (can be slightly tilted)
    @return false if the burger bun is flipped upside down
    */
    bool checkIfBunUpright()
    {
        if ((Vector3.Dot(LowerBun.transform.up, Vector3.up)) <= 1.0f && (Vector3.Dot(LowerBun.transform.up, Vector3.up)) >= 0.8f)
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
        if (Vector3.Distance(TopBun.transform.position, Patty.transform.position) <= 0.03f)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    /* Checks to see if the lower burger bun is correctly placed */
    bool isLowerBunCorrect()
    {
        if ((Vector3.Dot(LowerBun.transform.up, Vector3.up)) <= 1.0f && (Vector3.Dot(LowerBun.transform.up, Vector3.up)) >= 0.8f)
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
        if (Vector3.Distance(Patty.transform.position, LowerBun.transform.position) <= 0.03f)
        {
            return true;
        }

        else
        {
            return false;
        }

    }
}
