using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector3 touchPosition;
    private Touch touch;
   [SerializeField]
   private float borderZ;
   [SerializeField]
   private float borderY;
   [SerializeField]
   private bool setPositon = false ; 
   private float borderX ; 
    private Draggable draggingObject;
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
                if (hit.transform.gameObject.GetComponent<Draggable>() != null || hit.transform.gameObject.GetComponent<Water>() == null)
                {
                    hit.transform.GetComponent<Draggable>()?.init(borderX ,  borderY , borderZ , setPositon );
                    draggingObject = hit.transform.GetComponent<Draggable>();
                    draggingObject?.SetDragging(true);
                }
            }
            return;
        }
        if(touch.phase == TouchPhase.Moved)
        {

        }
        if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) 
        {
            draggingObject?.SetDragging(false);
            draggingObject = null;
            return;
        }
    }

    void Update()
    {
        Touch ();
    }
}
