using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float distance = 10000f;

    [SerializeField]
    GameObject Camera;

    private GameObject aim;
    private bool attached;

    void LateUpdate()
    {
        //if(Input.GetKey(KeyCode.Space))
            Attach();

        //if(Input.GetKey(KeyCode.LeftAlt))
            //Detach();
    }
    public void Attach()
    {
        if (CheckAttachablity() && aim.tag == "Aim"){
            aim.GetComponent<AttachReceiver>().Attach(gameObject);
            Camera.GetComponent<Dragging>().UnDrag();
            transform.SetParent(aim.transform);
            attached = true;
        }

    }
    public void Detach()
    {
        aim.GetComponent<AttachReceiver>().Detach(gameObject);
        transform.SetParent(null);
        attached = false;
    }
    private bool CheckAttachablity()
    {
        Vector3 camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position;
        Vector3 dest = transform.position;
        Vector3 direction = Vector3.Normalize(dest - camera);
        Ray ray = new Ray(dest, direction);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance))
        {
            //Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            aim = hitInfo.collider.gameObject;
            return true;
        }
        else
        {
            //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.blue);
            return false;

        }
    }

    public bool isAttached(){
        return attached;
    }
}
