using UnityEngine;

public class AttachReceiver : MonoBehaviour
{
    [SerializeField]
    Transform destinationAttachPoint;

    private bool attached = false;
    private Comparator comparator;
    [SerializeField] bool isLeft;

    void Awake(){
        comparator = GetComponentInParent<Comparator>();
    }
    public void ReceiveAttach(GameObject OriginGameObject)
    {
        if (!attached){
            OriginGameObject.transform.position = destinationAttachPoint.position  ;

            //Debug.DrawLine(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position, destinationAttachPoint.position , Color.red);
            Mass objectMass = OriginGameObject.GetComponent<Mass>();
            if (isLeft) comparator.AddMassToLeft(objectMass);
            else comparator.AddMassToRight(objectMass);
            attached = true;
        }
    }
    public void Release(GameObject go)
    {
        attached = false;
        comparator.RemoveMass(go.GetComponent<Mass>());
        // go.GetComponent<Dragging>().enabled = true;
    }

   
}
