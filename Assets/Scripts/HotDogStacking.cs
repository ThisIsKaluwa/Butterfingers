using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotDogStacking : MonoBehaviour
{

    public GameObject Bun;
    public GameObject Sausage;

    private bool isStacked = false;
  

    // Start is called before the first frame update
    void Start()
    {
         IsAllStackedScript.howManyThingsToStack ++;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Vector3.Distance(Bun.transform.position, Sausage.transform.position) <= 0.03f && !isStacked)
        {
            IsAllStackedScript.howManyThingsAreStacked++;
            Bun.GetComponent<Rigidbody>().isKinematic = true;
            Sausage.GetComponent<Rigidbody>().isKinematic = true;

            isStacked = true;
        }
    }
}
