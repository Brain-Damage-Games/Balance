using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
   private bool dragging = false; 
   private bool inBox = false;
   private bool setPositon = false ; 
   private float dist ;
   private float borderX ; 
   private float borderZ;
   private float borderY;
   private Vector3 offset;
   private ShelfSorting shelf;
   private Rigidbody rb;
   void Awake(){
    rb = GetComponent<Rigidbody>();
    shelf = GameObject.FindGameObjectWithTag("Shelf").GetComponent<ShelfSorting>();
   }
   public void SetDragging(bool dragging)
   {
       this.dragging = dragging;
       
       Attachable attachable = GetComponent<Attachable>();
       attachable.AllowAttachment(dragging);

       if (dragging && attachable.IsAttached()){
        attachable.Detach();
       }
       else if (dragging && inBox){
        shelf.TakeOut(gameObject);
        inBox = false;
       }
       if (dragging) rb.isKinematic = true;
       else if (!attachable.IsAttached()) rb.isKinematic = false;
    }
    public void init(float borderX  , float borderY , float borderZ  , bool setPositon)
    {
        this.borderX = borderX ;
        this.borderY = borderY ;
        this.borderZ = borderZ ; 
        this.setPositon = setPositon ; 
    }
    private void OnMouseDown()
    {
        if(setPositon)
        {
            gameObject.transform.position = new Vector3 (borderX , gameObject.transform.position.y , gameObject.transform.position.z);
        }
        dist = Camera.main.WorldToScreenPoint(gameObject.transform.position).z ;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }
    private void OnMouseDrag()
    {
        if (dragging)
        {
            gameObject.transform.position= GetMouseWorldPos() + offset;
            Limit () ;
        }
    }
    private void Limit () 
    {
        Vector3 newPos = gameObject.transform.position ; 
        newPos.z =Mathf.Clamp(newPos.z , -borderZ , borderZ);
        newPos.y =Mathf.Clamp(newPos.y , -borderY , borderY);
        gameObject.transform.position = newPos ; 
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = dist;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    public bool IsDragging(){
        return dragging;
    }
    public void SetInBox(bool inBox){
        this.inBox = inBox;
    }
    public bool IsInBox(){
        return inBox;
    }
}
