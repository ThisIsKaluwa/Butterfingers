using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This scene handles the preparation of the fries, which are served in a paper tray
This script needs to be attached to the tray the fries should be collected in*/
public class FriesScript : MonoBehaviour
{
    public GameObject Fry;

    int allTheFries = 5;

    List<GameObject> collectedFries = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        IsAllStackedScript.howManyThingsToStack++;
        SpawnTheFries(allTheFries);

    }

    // Update is called once per frame
    void Update()
    {
        if (collectedFries.Count == allTheFries)
        {
            IsAllStackedScript.howManyThingsAreStacked++;
        }

    }

    /* Instantiate a set amount of fries somewhere in the scene thats reachable by hand */
    void SpawnTheFries(int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            Instantiate(Fry, new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, -0.2f), Random.Range(0.3f, 0.5f)), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            collectedFries.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collectable")
        {
            collectedFries.Remove(other.gameObject);
        }
    }
}
