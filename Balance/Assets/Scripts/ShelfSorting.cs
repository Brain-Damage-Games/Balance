using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShelfSorting : MonoBehaviour
{
    GameObject[] objects;
    [SerializeField]
    GameObject cube;
    float shelfStart;
    float shelfEnd;
    int witchFloor = 0;
    GameObject[] maxObjectLengthPerFloor;
    float maxLength = 0f;
    float yPosition;
    // Start is called before the first frame update
    void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("Objects");

        maxObjectLengthPerFloor = new GameObject[100];

        yPosition = transform.localPosition.y + 2f;

        shelfStart = transform.position.x - transform.localScale.x / 2f + 1f;
        shelfEnd = transform.position.x + transform.localScale.x / 2f;

        Sort();

        //MovingToStart();
    }

    public void Sort()
    {
        //Sorting the objects
        for(int i = 0; i < objects.Length; i++)
        {
            
            objects[i].transform.position = new Vector3(
                shelfStart,
                yPosition,
                transform.localPosition.z);

            shelfStart = shelfStart + 1.2f;
            
        }
    }

    public void MovingToStart()
    {
        cube.transform.position = new Vector3(
            shelfStart + 0.2f + cube.GetComponent<Collider>().bounds.size.x / 2f,
            transform.localPosition.y + gameObject.GetComponent<Collider>().bounds.size.y / 2f + 1f,
            transform.localPosition.z);
    }


}
