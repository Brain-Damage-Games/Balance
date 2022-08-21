using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    GameObject[] allObjects;

    [SerializeField]
    GameObject water;

    void Awake() {
        allObjects = GameObject.FindGameObjectsWithTag("Objects");
    }

    bool IsWon()
    {
        foreach(GameObject gameObject in allObjects)
            if(!gameObject.GetComponent<Attachable>().IsAttached())
                return false;

        if(water.GetComponent<Water>().GetObjectInWater() != 0)
            return false;

        return true;
    }
}
