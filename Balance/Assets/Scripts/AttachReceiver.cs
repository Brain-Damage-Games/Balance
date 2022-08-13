using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;

    [SerializeField]
    Transform parent;
    private Comparator comparator;
    [SerializeField] bool isLeft;

    void Awake(){
        comparator = GetComponentInParent<Comparator>();
    }

    public void Attach(GameObject OriginGameObject)
    {
        OriginGameObject.transform.position = destinationAttachPoint.position;
        
        if (isLeft) comparator.AddMassToLeft(OriginGameObject.GetComponent<Mass>());
        else comparator.AddMassToRight(OriginGameObject.GetComponent<Mass>());
    }
    public void Detach(GameObject go)
    {
        comparator.RemoveMass(go.GetComponent<Mass>());
    }

}
