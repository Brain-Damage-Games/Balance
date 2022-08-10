using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour 
{
    [SerializeField, Min(0f)]
    private float mass;

    public Mass(float mass){
        SetMass(mass);
    }

    public void SetMass(float mass){
        this.mass = mass;
    }

    public float GetMass(){
        return mass;
    }
}