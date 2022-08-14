using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBtn : MonoBehaviour
{
    [SerializeField]
    GameObject shelf;
    
    private void OnMouseDown() {
        shelf.GetComponent<ShelfSorting>().ShiftRight();
    }
}
