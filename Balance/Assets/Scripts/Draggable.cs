using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
   public static Draggable I;
   private bool dragging = false; 
   private float dist ;
   private Vector3 ScreenPoint ;
   private Vector3 offset ;

   private void Awake() {
        if(I != this)
        {
            I = this;
        }
    }
   public void SetDragging(bool dragging)
   {
       this.dragging = dragging;
   }
   private void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(gameObject.transform.position).z ;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }
    private void OnMouseDrag()
    {
        if (dragging)
        {
            gameObject.transform.position = GetMouseWorldPos() + offset;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 MousePoint = Input.mousePosition;
        MousePoint.z = dist;
        return Camera.main.ScreenToWorldPoint(MousePoint);
    }
}
