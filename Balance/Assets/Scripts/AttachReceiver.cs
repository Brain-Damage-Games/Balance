using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;
    
    private bool Attached = false;
   
    public void Attach(GameObject OriginGameObject)
    {
        OriginGameObject.transform.position = destinationAttachPoint.position  ;

        Debug.DrawLine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position, destinationAttachPoint.position , Color.red);

        //here add the code to add the weight of object to scale
        OriginGameObject.GetComponent<Dragging>().enabled = false;
    }
    public void Detach(GameObject go)
    {
        //here add the code to omit the weight of object to scale
        go.GetComponent<Dragging>().enabled = true;
    }
}
