using UnityEngine;

public class CharacterRandomMovement : MonoBehaviour
{
    [SerializeField]
    float restTime = 2f;

    [SerializeField]
    float radius = 20f;

    [SerializeField]
    float speed=5f;
    
    Rigidbody rb;
    Vector3 originPosition;
    float time;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        originPosition = transform.position;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > restTime)
        {
            Target();
            time = 0;
        }
    }
    void Target()
    {
        float newX = Random.Range(originPosition.x - radius, originPosition.x + radius);
        float newZ = Random.Range(originPosition.z - radius, originPosition.z + radius);

        Vector3 destination = new Vector3(newX, originPosition.y, newZ);
        rb.AddForce ((destination - transform.position).normalized * speed);

    }
}
