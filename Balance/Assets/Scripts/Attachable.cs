using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float distance = 10000f;

    private Vector3 cameraPos;

    private bool attached = false;

    private GameObject aim;


    private bool triggerAttachabality = false;

    private void Awake()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position; 
    }
    void Update()
    {
        if(!attached)
            Attach();

    }
    public void Attach()
    {
        
        if ((CheckAttachablity() || triggerAttachabality) && aim.tag == "Aim")
        {

            aim.GetComponent<AttachReceiver>().ReceiveAttach(gameObject);
            attached = true;
        }
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
        attached=false;
    }
    private bool CheckAttachablity()
    {
        Vector3 camera = cameraPos ;
        Vector3 dest = transform.position;
        Vector3 direction = Vector3.Normalize(dest - camera);
        Ray ray = new Ray(dest, direction);
        Ray ray2 = new Ray(dest, -direction);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance) || (Physics.Raycast(ray2, out hitInfo, distance)))
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
}
