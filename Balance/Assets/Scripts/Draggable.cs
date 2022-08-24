using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
   private bool dragging = false; 
   private float dist ;
   [SerializeField]
   private float borderX;
   [SerializeField]
   private float borderY;
   private Vector3 offset ;
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
            gameObject.transform.position= GetMouseWorldPos() + offset;
            Limit () ;
        }
    }
    private void Limit () 
    {
        Vector3 newPos = gameObject.transform.position ; 
        newPos.x =Mathf.Clamp(newPos.x , -borderX , borderX);
        newPos.y =Mathf.Clamp(newPos.y , -borderY , borderY);
        gameObject.transform.position = newPos ; 
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = dist;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
