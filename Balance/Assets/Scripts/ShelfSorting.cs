using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShelfSorting : MonoBehaviour
{
    GameObject[] objects;
    [SerializeField]
    float space = 1.2f;
    float shelfStart;
    float shelfEnd;
    float yPosition;

    // Start is called before the first frame update
    void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("Objects");

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

            shelfStart = shelfStart + space;
            
        }
    }


}
