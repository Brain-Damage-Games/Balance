using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public delegate void endOfGame();
    public static event endOfGame EndOfGame;

    GameObject[] allObjects;

    [SerializeField]
    GameObject water;
    private bool alreadyWon = false;

    void Awake() {
        allObjects = GameObject.FindGameObjectsWithTag("Objects");
    }

    public bool IsWon()
    {
        if (alreadyWon) return false;
        foreach(GameObject gameObject in allObjects)
            if(!gameObject.GetComponent<Attachable>().IsAttached())
                return false;

        if(water.GetComponent<Water>().GetObjectInWater() != 0)
            return false;

        EndOfGame();
        alreadyWon = true;
        return true;
    }
}
