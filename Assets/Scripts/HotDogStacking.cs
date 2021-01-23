using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles the construction of a hotdog 
A hotdog consists of two buns, a sausage and three cucumbers
*/
public class HotDogStacking : MonoBehaviour
{

    public GameObject Bun;
    public GameObject Sausage;
    public GameObject[] Cucumbers;
    public GameObject SecondBun;

    private bool isStacked = false;

    Renderer[] condiments;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<IsAllStackedScript>().howManyThingsToStack++; //add one to the total of items needed to be stacked
        condiments = Sausage.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool cucumbersCorrect = areCucumbersCorrect();
        bool condimentsCorrect = areCondimentsCorrect();

        if (Vector3.Distance(Bun.transform.position, Sausage.transform.position) <= 0.12f &&
            Vector3.Distance(SecondBun.transform.position, Sausage.transform.position) <= 0.12f && cucumbersCorrect && condimentsCorrect && !isStacked)
        {
            GetComponent<IsAllStackedScript>().howManyThingsAreStacked++;
            Bun.GetComponent<Rigidbody>().isKinematic = true;
            Sausage.GetComponent<Rigidbody>().isKinematic = true;

            foreach (GameObject cucumber in Cucumbers)
            {
                cucumber.GetComponent<Rigidbody>().isKinematic = true;
            }

            isStacked = true;
        }
    }

    /* Checks if 3 cucumbers are placed correctly */
    bool areCucumbersCorrect()
    {
        int correct = 0;

        foreach (GameObject cucumber in Cucumbers)
        {
            if (Vector3.Distance(Sausage.transform.position, cucumber.transform.position) <= 0.1f)
            {
                correct++;
            }
        }

        if (correct == 3)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    /* Checks if mustard and ketchup are spawned, must both be on the same side */
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
