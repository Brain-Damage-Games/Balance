using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float distance = 10000f;


    private bool checkedAttachabality=false;

    private GameObject aim;
    //private Vector3 cameraPosition;

    /*private void Awake()
    {
        cameraPosition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
    }*/
    void LateUpdate()
    {
            Attach();
    }
    public void Attach()
    {
        
        if ((CheckAttachablity() || checkedAttachabality) && aim.tag == "Aim")
            aim.GetComponent<AttachReceiver>().Attach(gameObject);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        print("collides");
    }*/
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Aim")
        {
            aim = other.gameObject;
            checkedAttachabality = true;
        }
        else
            checkedAttachabality = false;
    }
    public void Detach()
    {
        aim.GetComponent<AttachReceiver>().Detach(gameObject);
    }
    private bool CheckAttachablity()
    {
        Vector3 camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
        Vector3 dest = transform.position;
        Vector3 direction = Vector3.Normalize(dest - camera);
        Ray ray = new Ray(dest, direction);
        Ray ray2 = new Ray(dest, -direction);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance) || (Physics.Raycast(ray2, out hitInfo, distance)))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
            aim = hitInfo.collider.gameObject;
            return true;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
            Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * 100, Color.blue);
            return  false;

        }
    }
}
