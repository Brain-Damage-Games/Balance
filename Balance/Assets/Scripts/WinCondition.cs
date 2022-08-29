using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public delegate void endOfGame();
    public static event endOfGame EndOfGame;

    GameObject[] allObjects;
    public Attachable[] attachables;

    [SerializeField]
    GameObject water;
    private bool alreadyWon = false;
    [SerializeField] Comparator[] scales; 

    void Awake() {
        // allObjects = GameObject.FindGameObjectsWithTag("Objects");
        // foreach (GameObject gameObject in allObjects){
        //     if (gameObject.GetComponent<Attachable>() == null) attachables.Add(gameObject.GetComponentInChildren<Attachable>());
        //     else attachables.Add(gameObject.GetComponent<Attachable>());
        // }
        // attachables = Resources.FindObjectsOfTypeAll<Attachable>();
    }

    public bool IsWon()
    {
        if (alreadyWon) return false;
        foreach (Comparator scale in scales){
            if (scale.IsRotating()) return false;
        }
        foreach(Attachable attachable in attachables){
            if (!attachable.IsAttached()) return false;
        }

        if(water.GetComponent<Water>().GetObjectInWater() != 0)
            return false;

        EndOfGame();
        alreadyWon = true;
        return true;
    }
}
