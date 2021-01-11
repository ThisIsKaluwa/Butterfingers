using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCondimentScript : MonoBehaviour
{
    // Start is called before the first frame update

    static bool thereIsMustard;
    static bool thereIsKetchup;

    void Start()
    {
        thereIsKetchup = false;
        thereIsMustard = false;
    }

    // Update is called once per frame
    public static void SetCondiment(string name)
    {
        if (name == "mustard")
        {
            thereIsMustard = true;
        }

        if (name == "ketchup")
        {
            thereIsKetchup = true;
        }
    }

    public static bool IsThereCondiment(string name)
    {
        if (name == "mustard")
        {
            return thereIsMustard;
        }

        if (name == "ketchup")
        {
            return thereIsKetchup;
        }

        else
        {
            return false;
        }
    }
}
