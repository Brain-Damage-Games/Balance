using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfSorting : MonoBehaviour
{
    GameObject[] allObjects;
    List<GameObject> seenObjects;

    [SerializeField]
    float space = 0.4f;

    float shelfStartPosition, shelfEndPosition;
    int firstObjectIndex, lastObjectIndex;
    void Awake()
    {
        allObjects = GameObject.FindGameObjectsWithTag("Objects");
        seenObjects = new List<GameObject>(6);

        if(allObjects.Length > 6)
        {
            for(int i = 0; i <= 5; i++)
                seenObjects.Add(allObjects[i]);
            
            for(int i = 6; i < allObjects.Length; i++)
                allObjects[i].SetActive(false);

            firstObjectIndex = 0;
            lastObjectIndex = 5;
            
        }
        else
            for(int i = 0; i < allObjects.Length; i++)
                seenObjects.Add(allObjects[i]);

        Sort();
    }

    //***** this function will gave the gameObjects their position;
    public void Sort()
    {
        shelfStartPosition = transform.position.z - transform.localScale.z / 2f + 1f;
        shelfEndPosition = transform.position.z + transform.localScale.z / 2f - 1f;

        for(int i = 0; i < seenObjects.Count; i++)
        {
            print(seenObjects[i].name + " + ");
            seenObjects[i].transform.position = new Vector3(
                transform.localPosition.x,
                transform.position.y + 1f,
                shelfStartPosition + space + 0.5f );
            
            shelfStartPosition = shelfStartPosition + space + 1f;
           
        }
    }

    public void ShiftRight()
    {
        if(allObjects.Length > 6 && lastObjectIndex < allObjects.Length - 1)
        {
            seenObjects[0].SetActive(false);
            seenObjects.RemoveAt(0);
            seenObjects.Insert(5, allObjects[lastObjectIndex + 1]);
            allObjects[lastObjectIndex + 1].SetActive(true);

            firstObjectIndex++;
            lastObjectIndex++;

            Sort();
        }
    }

    public void ShiftLeft()
    {
        if(allObjects.Length > 6 && firstObjectIndex > 0)
        {
            seenObjects[5].SetActive(false);
            seenObjects.RemoveAt(5);
            seenObjects.Insert(0, allObjects[firstObjectIndex - 1]);
            allObjects[firstObjectIndex - 1].SetActive(true);

            lastObjectIndex--;
            firstObjectIndex--;

            Sort();
        }
    }

    public void TakeOut(GameObject takingOut)
    {

    }

}
