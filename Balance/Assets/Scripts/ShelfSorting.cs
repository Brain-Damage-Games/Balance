using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfSorting : MonoBehaviour
{
    List<GameObject> allObjects;
    List<GameObject> seenObjects;

    [SerializeField]
    GameObject[] buttons;

    float space, objectsScale;
    List<Vector3> scaleOfObjects;

    float shelfStartPosition, shelfEndPosition;
    int firstObjectIndex, lastObjectIndex;
    void Awake()
    {
        TurnToList(GameObject.FindGameObjectsWithTag("Objects"));
        ChangeTheScale();
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


        space = transform.localScale.x * 0.036f;
        objectsScale = transform.localScale.x / 11f;

        shelfStartPosition = transform.position.x - transform.localScale.x / 2f;
        shelfEndPosition = transform.position.x + transform.localScale.x / 2f;  

        // buttons[0].transform.position = new Vector3
        // (
        //     shelfStartPosition + objectsScale / 2,
        //     transform.position.y + objectsScale,
        //     transform.localPosition.z
        // );
        // buttons[1].transform.position = new Vector3
        // (
        //     shelfEndPosition - objectsScale / 2,
        //     transform.position.y + objectsScale,
        //     transform.localPosition.z
        // );


        Sort();
    }

    private void TurnToList(GameObject[] ObjetsArray)
    {
        allObjects = new List<GameObject>();

        for(int i = 0; i < ObjetsArray.Length; i++){
            allObjects.Add(ObjetsArray[i]);
            ObjetsArray[i].GetComponent<Draggable>()?.SetInBox(true);
        }
        
    }

    //***** this function will gave the gameObjects their position;
    public void Sort()
    {
        shelfStartPosition = transform.position.x - transform.localScale.x / 2f + objectsScale;
        shelfEndPosition = transform.position.x + transform.localScale.x / 2f - objectsScale;

        for(int i = 0; i < seenObjects.Count; i++)
        {
            if (seenObjects[i].transform.parent != null)
                seenObjects[i].transform.parent.position = new Vector3(
                    shelfStartPosition + space + objectsScale / 2,
                    transform.position.y + objectsScale,
                    transform.localPosition.z);
            else
                seenObjects[i].transform.position = new Vector3(
                    shelfStartPosition + space + objectsScale / 2,
                    transform.position.y + objectsScale,
                    transform.localPosition.z);
            shelfStartPosition = shelfStartPosition + space + objectsScale;
           
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
        print("Taken");
        takingOut.transform.position = new Vector3(takingOut.transform.position.x, takingOut.transform.position.y + 2f, takingOut.transform.position.z);
        takingOut.transform.localScale = scaleOfObjects[allObjects.IndexOf(takingOut)];

        int allObjectsCount = allObjects.Count;
        scaleOfObjects.RemoveAt(allObjects.IndexOf(takingOut));
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
            seenObjects.Insert(0, allObjects[firstObjectIndex - 1]);
            allObjects[firstObjectIndex - 1].SetActive(true);
            lastObjectIndex--;
            firstObjectIndex--;
            Sort();
        }
    }

    private void ChangeTheScale()
    {
        scaleOfObjects = new List<Vector3>();
        for (int i = 0; i < allObjects.Count; i++)
            scaleOfObjects.Add(allObjects[i].transform.localScale);

        for(int i = 0; i < allObjects.Count; i++)
            allObjects[i].transform.localScale = new Vector3
            (
                transform.localScale.x / 11f,
                transform.localScale.x / 11f,
                transform.localScale.x / 11f
            ) ;

        for(int i = 0; i < buttons.Length; i++)
            buttons[i].transform.localScale = new Vector3
            (
                transform.localScale.x / 11f,
                transform.localScale.x / 11f,
                transform.localScale.x / 11f
            );
        
    }

   

}
