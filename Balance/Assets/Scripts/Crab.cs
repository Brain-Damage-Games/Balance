using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    Animator animator;

    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable() {
        WinCondition.EndOfGame += Dance;
    }

    private void OnDisable() {
        WinCondition.EndOfGame -= Dance;
    }

    public void Dance()
    {
        animator.SetBool("Dance", true);
    }
}
