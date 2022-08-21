using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector3 TouchPosition;
    private Touch touch;
    private void Touch ()
    {
        if (Input.touchCount != 1 )
        {
            return ;
        }

        touch = Input.touches[0];
        TouchPosition = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(TouchPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit))
            {
               if (hit.transform.gameObject.GetComponent<Draggable>() != null)
               {
                  Draggable.I.SetDragging(true);
               }
            }
        }
        if(touch.phase == TouchPhase.Moved)
        {

        }

        if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) 
        {
           Draggable.I.SetDragging(false);
        }
    }
    void Update()
    {
        Touch ();
    }
}
