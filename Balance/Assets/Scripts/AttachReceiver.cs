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
        OriginGameObject.transform.SetParent(gameObject.transform);
    }
    public void Detach(GameObject go)
    {
        go.transform.SetParent(parent);
    }

}
