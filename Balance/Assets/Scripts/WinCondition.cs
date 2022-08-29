using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    private SoundEffectManager sound;
    private ProgressBar progress;
    void Awake() {
      //  PlayerPrefs.SetInt("Level", 1);
        sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffectManager>();
        
        // allObjects = GameObject.FindGameObjectsWithTag("Objects");
        // foreach (GameObject gameObject in allObjects){
        //     if (gameObject.GetComponent<Attachable>() == null) attachables.Add(gameObject.GetComponentInChildren<Attachable>());
        //     else attachables.Add(gameObject.GetComponent<Attachable>());
        // }
        // attachables = Resources.FindObjectsOfTypeAll<Attachable>();
    }

    private void Start()
    {
        progress = GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>();
    }
    public bool IsWon()
    {

        if (alreadyWon) 
        {
            progress.Fill(1);
            return false;
        } 
        foreach (Comparator scale in scales){
            if (scale.IsRotating()) return false;
        }
        foreach(Attachable attachable in attachables){
            if (!attachable.IsAttached()) return false;
        }

        if (water.GetComponent<Water>().GetObjectInWater() != 0)
            return false;

       
        sound.PlayWinSound();
    
        Vibrator.Vibrate(25);
        StartCoroutine(LoadNext());

        EndOfGame();
        alreadyWon = true;
        return true;
    }

    IEnumerator LoadNext() 
    {
        
        yield return new WaitForSeconds(3.5f);
        LevelChanger.LoadNextLevel();
    }
}
