using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;

    [SerializeField]
    Transform parent;

    public void Attach(GameObject OriginGameObject)
    {
        OriginGameObject.transform.position = destinationAttachPoint.position;
        //here add the code to add the weight of object to scale
    }
    public void Detach(GameObject go)
    {
        //here add the code to omit the weight of object to scale
    }

}
