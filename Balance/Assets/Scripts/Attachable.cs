using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float distance = 10000f;

    [SerializeField]
    GameObject Camera;

    private GameObject aim;

    void LateUpdate()
    {
        //if(Input.GetKey(KeyCode.Space))
            Attach();

        //if(Input.GetKey(KeyCode.LeftAlt))
            //Detach();
    }
    public void Attach()
    {
        if (CheckAttachablity() && aim.tag == "Aim")
            aim.GetComponent<AttachReceiver>().Attach(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("collides");
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
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            aim = hitInfo.collider.gameObject;
            return true;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
            Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * 100, Color.blue);
            return false;

        }
    }
}
