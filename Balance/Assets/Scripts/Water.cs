using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
    public int objectInWater=0;
    private SoundEffectManager sound;

    private void Awake()
    {
        sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffectManager>();
    }

    void OnTriggerEnter(Collider col){
        sound.PlayWaterSound();
            objectInWater += 1;
    }

    void OnTriggerExit(Collider col){
            objectInWater -= 1;
    }

    public int GetObjectInWater()
    {
        return objectInWater;
    }
   
}
