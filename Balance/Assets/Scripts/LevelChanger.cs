using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelChanger
{
    public static void LoadNextLevel() 
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        if (SceneManager.sceneCountInBuildSettings > PlayerPrefs.GetInt("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        else 
        {
            LoadMenu();
        }
    }

    public static void LoadCurrentLevel() 
    {
        if (PlayerPrefs.GetInt("Level") == 0)
            PlayerPrefs.SetInt("Level", 1);

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public static void LoadMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
