using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float zDistance = 10000f;


    private GameObject aim;

    void Update()
    {
        Attach();
    }
    public void Attach()
    {
        if (CheckAttachablity() && aim.tag == "aim")
            aim.GetComponent<AttachReceiver>().Attach(gameObject);
    }
   private bool CheckAttachablity()
    {
        Ray ray1 = new Ray(transform.position, transform.right);
        Ray ray2 = new Ray(transform.position, -transform.right);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray1, out hitInfo, zDistance) || Physics.Raycast(ray2, out hitInfo, zDistance))
        {
            float deltaZ = Mathf.Abs(transform.position.z - hitInfo.point.z);
            float deltaY = Mathf.Abs(transform.position.y - hitInfo.point.y);

            if (deltaZ <= 1 && deltaY <= 1)
            {
                aim = hitInfo.collider.gameObject;
                //Debug.DrawLine(ray1.origin, hitInfo.point, Color.red);
                //print(hitInfo.collider.gameObject.name);
                return true;
            }
            else
                return false;
        }
        else
        {
            //Debug.DrawLine(ray1.origin, ray1.origin + ray1.direction * 100, Color.blue);
            //Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * 100, Color.black);
            return false;

        }
    }


}
