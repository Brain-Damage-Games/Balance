using UnityEngine;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject xMark, gameObjects;

    [SerializeField]
    private TextMeshProUGUI level;

    private SoundEffectManager sound;

    private void Awake()
    {
        sound = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffectManager>();
        level.text = PlayerPrefs.GetInt("Level").ToString();
        if(PlayerPrefs.GetInt("Vibration") == 0)
            xMark.SetActive(false);
        else
            xMark.SetActive(true);
    }

    public void StartGame() 
    {
        LevelChanger.LoadCurrentLevel();
    }

    public void TTP() 
    {
        sound.PlaySelctSound();
        gameObjects.SetActive(true);
        gameObject.SetActive(false);
    }

    public void VibrationSetting() 
    {
        sound.PlaySelctSound();
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
