using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
    public int objectInWater=0;


    void OnTriggerEnter(Collider col){
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
