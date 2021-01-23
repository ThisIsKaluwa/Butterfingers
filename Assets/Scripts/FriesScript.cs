using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This scene handles the preparation of the fries, which are served in a paper tray
This script needs to be attached to the tray the fries should be collected in*/
public class FriesScript : MonoBehaviour
{
    public GameObject Fry;

    Renderer[] ketchup;
    int allTheFries = 5;

    List<GameObject> collectedFries = new List<GameObject>();

    IsAllStackedScript doneScript;
    // Start is called before the first frame update
    void Start()
    {
        doneScript = GameObject.Find("Scriptholder").GetComponent<IsAllStackedScript>();
        doneScript.howManyThingsToStack++;
        SpawnTheFries(allTheFries);
        ketchup = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (collectedFries.Count == allTheFries && ketchup[1].enabled)
        {
           doneScript.howManyThingsAreStacked++;
        }

    }

    /* Instantiate a set amount of fries somewhere in the scene thats reachable by hand */
    void SpawnTheFries(int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            Instantiate(Fry, new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, -0.2f), Random.Range(0.6f, 0.5f)), Quaternion.identity);
        }
    }

    /* Counts how many fries are put into the tray */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            collectedFries.Add(other.gameObject);
        }
    }

     /* Counts how many fries exit the tray */
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collectable")
        {
            collectedFries.Remove(other.gameObject);
        }
    }
}
