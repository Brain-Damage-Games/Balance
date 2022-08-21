using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] 
    private GameObject prefab;
    public void Instantiate ()
    {
        GameObject go = Instantiate (prefab);
        go.transform.position = transform.position;
        go.transform.parent = null ;
    }
}
