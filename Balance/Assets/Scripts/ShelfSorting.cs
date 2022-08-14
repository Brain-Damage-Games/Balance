using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfSorting : MonoBehaviour
{
    List<GameObject> allObjects;
    List<GameObject> seenObjects;

    [SerializeField]
    float space = 0.4f;

    float shelfStartPosition, shelfEndPosition;
    int firstObjectIndex, lastObjectIndex;
    void Awake()
    {
        TurnToList(GameObject.FindGameObjectsWithTag("Objects"));
        seenObjects = new List<GameObject>(6);

        if(allObjects.Count > 6)
        {
            for(int i = 0; i <= 5; i++)
                seenObjects.Add(allObjects[i]);
            
            for(int i = 6; i < allObjects.Count; i++)
                allObjects[i].SetActive(false);

            firstObjectIndex = 0;
            lastObjectIndex = 5;
            
        }
        else
            for(int i = 0; i < allObjects.Count; i++)
                seenObjects.Add(allObjects[i]);

        Sort();
    }

    private void TurnToList(GameObject[] ObjetsArray)
    {
        allObjects = new List<GameObject>();

        for(int i = 0; i < ObjetsArray.Length; i++)
            allObjects.Add(ObjetsArray[i]);
        
    }

    //***** this function will gave the gameObjects their position;
    public void Sort()
    {
        shelfStartPosition = transform.position.z - transform.localScale.z / 2f + 1f;
        shelfEndPosition = transform.position.z + transform.localScale.z / 2f - 1f;

        for(int i = 0; i < seenObjects.Count; i++)
        {
            seenObjects[i].transform.position = new Vector3(
                transform.localPosition.x,
                transform.position.y + 1f,
                shelfStartPosition + space + 0.5f );
            
            shelfStartPosition = shelfStartPosition + space + 1f;
           
        }
    }

    public void ShiftRight()
    {
        if(allObjects.Count > 6 && lastObjectIndex < allObjects.Count - 1)
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
        if(allObjects.Count > 6 && firstObjectIndex > 0)
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

    //***** this function will sort the objects when one of them taked out;
    public void TakeOut(GameObject takingOut)
    {

        takingOut.transform.position = new Vector3(takingOut.transform.position.x, takingOut.transform.position.y + 2f, takingOut.transform.position.z);

        int allObjectsCount = allObjects.Count;
        seenObjects.Remove(takingOut);
        allObjects.Remove(takingOut);

        if (allObjectsCount <= 6)
            Sort();
        
        else if(lastObjectIndex < allObjectsCount - 1)
        {
            
            seenObjects.Insert(5, allObjects[lastObjectIndex]);
            allObjects[lastObjectIndex].SetActive(true);
            Sort();
        }
        else
        {
            print("in third if");
            seenObjects.Insert(0, allObjects[firstObjectIndex - 1]);
            allObjects[firstObjectIndex - 1].SetActive(true);
            lastObjectIndex--;
            firstObjectIndex--;
            Sort();
        }
    }

   

}
