using UnityEngine;

public class Attachable : MonoBehaviour
{
    [SerializeField]
    float zDistance = 10000f;

    void Update()
    {
        Ray ray1 = new Ray(transform.position, transform.right);
        Ray ray2 = new Ray(transform.position, -transform.right);
        RaycastHit hitInfo;

        if ( Physics.Raycast(ray1,out hitInfo,zDistance) || Physics.Raycast(ray2, out hitInfo, zDistance))
        {
            float deltaZ = Mathf.Abs(transform.position.z - hitInfo.point.z);
            float deltaY = Mathf.Abs(transform.position.y - hitInfo.point.y);

            if (deltaZ<=1 && deltaY <= 1) 
            {
                Debug.DrawLine(ray1.origin, hitInfo.point, Color.red);
                print(hitInfo.collider.gameObject.name);
            }
        }
        else
        {
            Debug.DrawLine(ray1.origin, ray1.origin + ray1.direction * 100, Color.blue);
            Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * 100, Color.black);
        }

    }
}
