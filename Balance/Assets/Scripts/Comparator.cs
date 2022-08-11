using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparator : MonoBehaviour
{
    private bool heavyRight = false;
    private bool heavyLeft = false;
    private float leftMass = 0, rightMass = 0;
    private bool isRotating = false;

    void Update(){
        if (isRotating){
            Rotate();
        }
    }
    private void Rotate(){
        float angleOffset = (transform.rotation.eulerAngles.z > 180) ? transform.rotation.eulerAngles.z - 360 : transform.rotation.eulerAngles.z;
        float rotateSpeed = Mathf.Abs(rightMass - leftMass) * Mathf.Abs(30 - Mathf.Abs(angleOffset)) * Time.deltaTime;
        if (!heavyRight && heavyLeft && (transform.rotation.eulerAngles.z <= 25 || transform.rotation.eulerAngles.z >= 330)){
            transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + rotateSpeed);
        }
        
        else if (heavyRight && !heavyLeft && (transform.rotation.eulerAngles.z <= 30 || transform.rotation.eulerAngles.z >=  335)){
            transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z - rotateSpeed);
        }

        else if ((!heavyLeft && !heavyRight) || (heavyLeft && heavyRight)){
            if (transform.rotation.eulerAngles.z > 1 && transform.rotation.eulerAngles.z < 180){
                transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z - rotateSpeed);
            }
            else if (transform.rotation.eulerAngles.z > 180){
                transform.rotation = Quaternion.Euler(0,0,transform.rotation.eulerAngles.z + rotateSpeed);
            }
            else{
                transform.rotation = Quaternion.Euler(0,0,0);
                isRotating = false;
            }
        }
        else isRotating = false;
    }

    private void Compare(){
        if (leftMass > rightMass){
            heavyLeft = true;
            heavyRight = false;
        }
        else if (leftMass < rightMass){
            heavyLeft = false;
            heavyRight = true;
        }
        else{
            heavyLeft = false;
            heavyRight = false;
        }
        isRotating = true;
    }

    public void SetLeftMass(Mass mass){
        leftMass = mass.GetMass();
        Compare();
    }

    public void SetRightMass(Mass mass){
        rightMass = mass.GetMass();
        Compare();
    }

    public void RemoveMass(Mass mass){
        if (leftMass == mass.GetMass()) EmptyLeft();
        else if (rightMass == mass.GetMass()) EmptyRight();
    }

    public void EmptyLeft(){
        leftMass = 0f;
    }

    public void EmptyRight(){
        rightMass = 0f;
    }
}
