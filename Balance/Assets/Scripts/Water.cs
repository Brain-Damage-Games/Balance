using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
    public int objectInWater=0;


    void OnTriggerEnter(Collider col){
        if (col.gameObject.transform.parent?.tag == "Objects")
            objectInWater += 1;
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.transform.parent?.tag == "Objects")
            objectInWater -= 1;
    }

    public int GetObjectInWater()
    {
        return objectInWater;
    }
   
}
