using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Comparator : MonoBehaviour
{
    private bool heavyRight = false;
    private bool heavyLeft = false;
    private float leftMass = 0, rightMass = 0;
    private List<Mass> leftMassObjects, rightMassObjects;
    private bool isRotating = false;
    [SerializeField, Range(5f,50f)] float maxAngleOffset = 30f;
    private float angleOffset = 0f;
    private float angle;
    [SerializeField, Range(0f,10f)] float angleOffsetIncreasePerUnit = 2f;
    [SerializeField, Range(0.01f, 0.5f)] float baseSpeed = 0.1f;
    [SerializeField] Transform leftHook,rightHook;

    public TextMeshProUGUI leftText, rightText;
    void Awake(){
        leftMassObjects = new List<Mass>();
        rightMassObjects = new List<Mass>();
    }
    void Update(){
        if (isRotating){
            Rotate();
        }
        leftText.text = leftMass.ToString();
        rightText.text = rightMass.ToString();
    }
    private void Rotate(){
        angle = (transform.rotation.eulerAngles.z > 180) ? transform.rotation.eulerAngles.z - 360 : transform.rotation.eulerAngles.z;
        float rotateSpeed = Mathf.Abs(rightMass - leftMass) * Mathf.Abs(maxAngleOffset - Mathf.Abs(angle)) * Time.deltaTime * baseSpeed;
        float balanceSpeed = Mathf.Abs(maxAngleOffset - Mathf.Abs(angle)) * Time.deltaTime * baseSpeed * 2;
        if (leftMass > rightMass && angle < angleOffset && Mathf.Abs(angle - angleOffset) > angleOffsetIncreasePerUnit+1){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z + rotateSpeed);
            rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z - rotateSpeed);
        }
        else if (leftMass > rightMass && angle > angleOffset && Mathf.Abs(angle - angleOffset) > angleOffsetIncreasePerUnit+1){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z - rotateSpeed);
            rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z + rotateSpeed);
        }

        else if (rightMass > leftMass && angle > -angleOffset && Mathf.Abs(angle + angleOffset) > angleOffsetIncreasePerUnit+1){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z - rotateSpeed);
            rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z + rotateSpeed);
        }
        else if (rightMass > leftMass && angle < -angleOffset && Mathf.Abs(angle + angleOffset) > angleOffsetIncreasePerUnit+1){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z + rotateSpeed);
            rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z - rotateSpeed);
        }

        else if (leftMass == rightMass){
            if (angle > angleOffset){
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z - balanceSpeed);
                rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z + balanceSpeed);
            }
            else if (angle < angleOffset){
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z + balanceSpeed);
                rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,leftHook.localRotation.eulerAngles.z - balanceSpeed);
            }
            if (Mathf.Abs(angle) < 0.5){
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,0);
                rightHook.localRotation = leftHook.localRotation = Quaternion.Euler(leftHook.localRotation.eulerAngles.x,leftHook.localRotation.eulerAngles.y,0);
                isRotating = false;
            }
        }
        else isRotating = false;

    }

    private void Compare(){
        angleOffset = Mathf.Abs(leftMass - rightMass) * angleOffsetIncreasePerUnit;
        if (angleOffset > maxAngleOffset) angleOffset = maxAngleOffset;

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

    public void AddMassToLeft(Mass mass){
        leftMassObjects.Add(mass);
        leftMass += mass.GetMass();
        Compare();
    }

    public void AddMassToRight(Mass mass){
        rightMassObjects.Add(mass);
        rightMass += mass.GetMass();
        Compare();
    }

    public void RemoveMass(Mass mass){
        if (rightMassObjects.Contains(mass)) {
            rightMassObjects.Remove(mass);
            rightMass -= mass.GetMass();
        }
        else if (leftMassObjects.Contains(mass)) {
            leftMassObjects.Remove(mass);
            leftMass -= mass.GetMass();
        }
        Compare();
    }

    public void EmptyLeft(){
        leftMassObjects.Clear();
        leftMass = 0f;
    }

    public void EmptyRight(){
        rightMassObjects.Clear();
        rightMass = 0f;
    }
}
