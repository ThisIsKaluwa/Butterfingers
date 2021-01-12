using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script handles the playing of the background music throughout the game*/
public class MusicPlayerScript : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
