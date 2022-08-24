using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;

    private bool attached = false;
    private Comparator comparator;
    [SerializeField] bool isLeft;

    void Awake(){
        comparator = GetComponentInParent<Comparator>();
    }
    public void ReceiveAttach(GameObject OriginGameObject)
    {
        if (!attached){
            OriginGameObject.transform.position = destinationAttachPoint.position;
            OriginGameObject.transform.SetParent(destinationAttachPoint);


            //Debug.DrawLine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position, destinationAttachPoint.position , Color.red);
            OriginGameObject.GetComponent<Draggable>().SetDragging(false);
            Mass objectMass = OriginGameObject.GetComponent<Mass>();
            if (isLeft) comparator.AddMassToLeft(objectMass);
            else comparator.AddMassToRight(objectMass);
            attached = true;
           
        }
    }
    public void Release(GameObject go)
    {
        go.transform.SetParent(null);
        comparator.RemoveMass(go.GetComponent<Mass>());
        attached = false;
    }

    public bool isEmpty(){
        return !attached;
    }

}
