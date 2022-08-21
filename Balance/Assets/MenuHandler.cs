using UnityEngine;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject xMark;

    [SerializeField]
    private TextMeshProUGUI level;

    private void Awake()
    {
        level.text = PlayerPrefs.GetInt("Level").ToString();
    }

    public void StartGame() 
    {
        LevelChanger.LoadCurrentLevel();
    }

    public void VibrationSetting() 
    {
        if (xMark.activeInHierarchy)
        {
            PlayerPrefs.SetInt("Vibration", 0);
            xMark.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Vibration", 1);
            xMark.SetActive(true);
        }
    }
}
