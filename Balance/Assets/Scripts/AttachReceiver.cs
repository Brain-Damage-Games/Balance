using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;
    
    private bool attached = false;
   
    public void Attach(GameObject OriginGameObject)
    {
        OriginGameObject.transform.position = destinationAttachPoint.position  ;

        //Debug.DrawLine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position, destinationAttachPoint.position , Color.red);

        //here add the code to add the weight of object to scale

        //OriginGameObject.GetComponent<Dragging>().enabled = false;
        attached = true;
    }
    public void Detach(GameObject go)
    {
        attached = false;
        //here add the code to omit the weight of object to scale
        go.GetComponent<Dragging>().enabled = true;
    }
}
