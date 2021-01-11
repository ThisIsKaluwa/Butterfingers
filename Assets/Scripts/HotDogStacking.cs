using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script handles the construction of a hotdog */
public class HotDogStacking : MonoBehaviour
{

    public GameObject Bun;
    public GameObject Sausage;

    public GameObject SecondBun;

    private bool isStacked = false;
  

    // Start is called before the first frame update
    void Start()
    {
         IsAllStackedScript.howManyThingsToStack ++; //add one to the total of items needed to be stacked
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Vector3.Distance(Bun.transform.position, Sausage.transform.position) <= 0.03f && Vector3.Distance(SecondBun.transform.position, Sausage.transform.position) <= 0.03f && !isStacked)
        {
            IsAllStackedScript.howManyThingsAreStacked++;
            Bun.GetComponent<Rigidbody>().isKinematic = true;
            Sausage.GetComponent<Rigidbody>().isKinematic = true;

            isStacked = true;
        }
    }
}
