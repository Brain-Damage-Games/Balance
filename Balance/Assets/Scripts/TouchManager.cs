using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector3 touchPosition;
    private Touch touch;
    private void Touch ()
    {
        if (Input.touchCount != 1 )
        {
            return;
        }
        touch = Input.touches[0];
        touchPosition = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit))
            {
               if (hit.transform.gameObject.GetComponent<Draggable>() != null)
               {
                    hit.transform.gameObject.GetComponent<Draggable>().SetDragging(true);
               }
            }
        }
        if(touch.phase == TouchPhase.Moved)
        {

        }
        if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) 
        {
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit))
            {
               if (hit.transform.gameObject.GetComponent<Draggable>() != null)
               {
                    hit.transform.gameObject.GetComponent<Draggable>().SetDragging(false);
               }
            }
        }
    }

    void Update()
    {
        Touch ();
    }
}
