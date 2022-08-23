using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;
    
    private bool attached = false;
   
    public void ReceiveAttach(GameObject OriginGameObject)
    {
        OriginGameObject.transform.position = destinationAttachPoint.position  ;

        //Debug.DrawLine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position, destinationAttachPoint.position , Color.red);

        //here add the code to add the weight of object to scale
        OriginGameObject.GetComponent<Draggable>().SetDragging(false);
    }
    public void Release(GameObject go)
    {
        attached = false;
        //here add the code to omit the weight of object to scale
       
    }

   
}
