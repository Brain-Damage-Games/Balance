using UnityEngine;
using TMPro;
public class TestVibration : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI amount;

    private long vibrationAmount = 500;


    private void Update()
    {
        amount.text = vibrationAmount.ToString();
    }

    public void TriggerVibration() 
    {
        //Enter Following Command To Call A Vibration
        Vibrator.Vibrate(vibrationAmount);
    }

    public void Add() 
    {
        vibrationAmount += 50;
    }

    public void Deduct() 
    {
        vibrationAmount -= 50;
    }

}
