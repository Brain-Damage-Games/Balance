using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentLevel, nextLevel;

    [SerializeField]
    private Image progress;

    private GameObject[] objects;
    private int count;

    private void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("Objects");
        count = objects.Length;
        currentLevel.text = PlayerPrefs.GetInt("Level").ToString();
        nextLevel.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
    }
    public void AddToBar() 
    {
        progress.fillAmount += (1 % count);
    }

    public void Deduct() 
    {
        progress.fillAmount -= (1 % count);
    }
}
