using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterRandomMovement : MonoBehaviour
{
    [SerializeField]
    float restTime = 2f;
    [SerializeField]
    float runningTime = 2f;

    [SerializeField]
    float radius = 20f;

    [SerializeField]
    float radius2 = 10f;

    [SerializeField]
    float speed1=30f;

    [SerializeField]
    float speed2 = 10f;

    [SerializeField]
    float frequency = 1;

    System.Random r = new System.Random();
    int rand;
    Rigidbody rb;
    Vector3 originPosition;
    float time;
    void Awake()
    {
        rand = r.Next(0, 2);
        rb = gameObject.GetComponent<Rigidbody>();
        originPosition = transform.position;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < runningTime)
        {
            //Circle();
            Move();
        }

        else if(time < runningTime+restTime)
        {
            rb.velocity = new Vector3(0,0,0);
        }

        else
        {
            time = 0;
            rand = r.Next(0, 2);
        }
    }

    private void Move()
    {
        if (rand == 0)
            Target();
        else
            Circle();
    }
    private void Target()
    {
        float newX = Random.Range(originPosition.x - radius, originPosition.x + radius);
        float newZ = Random.Range(originPosition.z - radius, originPosition.z + radius);

        Vector3 destination = new Vector3(newX, originPosition.y, newZ);
        rb.AddForce ((destination - transform.position).normalized * speed1);

    }

    /*void DoTarget()
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 1; i <= 10; i++)
        {
            float newX = Random.Range(originPosition.x - radius, originPosition.x + radius);
            float newZ = Random.Range(originPosition.z - radius, originPosition.z + radius);
            Vector3 destination = new Vector3(newX, originPosition.y, newZ);
            points.Add(destination);
        }

        transform.DoPath()
    }*/

    private void Circle()
    {
        float newX = originPosition.x + Mathf.Sin(frequency * Time.time) * radius2;// * radius;
        float newZ = originPosition.z + Mathf.Cos(frequency * Time.time) * radius2;// * radius;

        Vector3 destination = new Vector3(newX, originPosition.y, newZ);
        rb.velocity=((destination - transform.position).normalized * speed2);

    }
}
