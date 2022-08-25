using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    Animation animation;
    
    private void Awake() 
    {
        animation = gameObject.GetComponent<Animation>();
    }

    private void OnEnable() 
    {
        WinCondition.EndOfGame += Salute;
    }

    private void OnDisable() 
    {
        WinCondition.EndOfGame -= Salute;
    }

    public void Salute()
    {
        animation.Play("Salute");
    }

}
