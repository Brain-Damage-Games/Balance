using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float distance = 10000f;

    private Vector3 cameraPos;

    public bool attached = false;

    private GameObject aim;
    private bool triggerAttachabality = false;
    private bool allowAttach = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position; 
    }
    void Update()
    {
        if(!attached)
            Attach();

    }
    public void Attach()
    {
        
        if (allowAttach && (CheckAttachablity() || triggerAttachabality) && aim != null && aim.tag == "Aim" && !attached)
        {
            AttachReceiver attachReceiver = aim.GetComponent<AttachReceiver>();
            Draggable targetDraggable = aim.GetComponentInParent<Draggable>();
            if (attachReceiver.isEmpty() && (targetDraggable == null || !targetDraggable.IsInBox())){
                attachReceiver.ReceiveAttach(gameObject);
                attached = true;
                rb.isKinematic = true;
            }
        }
        else if (!allowAttach) aim = null;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Aim")
        {
            aim = other.gameObject;
            triggerAttachabality = true;
        }
        else
            triggerAttachabality = false;
    }
    public void Detach()
    {
        aim.GetComponent<AttachReceiver>().Release(gameObject);
        GetComponent<Comparator>()?.DetachAll();
        rb.isKinematic = false;
        StartCoroutine(Timer());
    }
    private bool CheckAttachablity()
    {
        Vector3 camera = cameraPos;
        Vector3 dest = transform.position;
        Vector3 direction = Vector3.Normalize(dest - camera);
        Ray ray = new Ray(dest, direction);
        Ray ray2 = new Ray(dest, -direction);
        RaycastHit hitInfo;

        if(!attached && (Physics.Raycast(ray, out hitInfo, distance) || (Physics.Raycast(ray2, out hitInfo, distance))))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
            aim = hitInfo.collider.gameObject;
            return true;
        }
        else
        {
            //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
            //Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * 100, Color.blue);
            return  false;

        }
    }
    public bool IsAttached()
    {
        return attached;
    }

    public Comparator GetTargetComparator(){
        if (aim != null){
            return aim.GetComponentInParent<Comparator>();
        }
        else return null;
    }

    private IEnumerator Timer(){
        yield return new WaitForSeconds(1f);
        aim = null;
        attached = false;
    }

    public void AllowAttachment(bool allowAttach){
        this.allowAttach = allowAttach;
    }
}
