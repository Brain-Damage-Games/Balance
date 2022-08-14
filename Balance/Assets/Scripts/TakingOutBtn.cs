using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingOutBtn : MonoBehaviour
{
    [SerializeField]
    GameObject shelf, animal;

    private void OnMouseDown() 
    {
        shelf.GetComponent<ShelfSorting>().TakeOut(animal);   
    }
}
