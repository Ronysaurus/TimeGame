using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_LevelManager : MonoBehaviour
{
    public static readonly int maxLevel = 1;

    static public void SetLevelCleared(int _level)
    {
        if (_level > PlayerPrefs.GetInt("levelCleared"))
        {
            PlayerPrefs.SetInt("levelCleared", _level);
        }
    }

    static public int GetLevelCleared()
    {
        return PlayerPrefs.GetInt("levelCleared");
    }

    public void LoadLevel(int _level)
    {
        SceneManager.LoadScene(_level);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(GetLevelCleared());
    }
}