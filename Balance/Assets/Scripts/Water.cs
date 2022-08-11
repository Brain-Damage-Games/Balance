using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
   public int objectInWater=0;

    void OnCollisionEnter(Collision collision){
        objectInWater+=1;
        Debug.Log(objectInWater);
    }

}
