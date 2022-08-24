using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour 
{
    [SerializeField, Min(0f)]
    private float mass;
    private Rigidbody rb;

    public Mass(float mass){
        SetMass(mass);
    }

    public void SetMass(float mass){
        this.mass = mass;
        if (rb != null) rb.mass = mass;
    }

    public float GetMass(){
        return mass;
    }
}