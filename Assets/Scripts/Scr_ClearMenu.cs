using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_ClearMenu : MonoBehaviour
{
    public void NextLevel()
    {
        int level = Scr_LevelManager.GetLevelCleared();
        if (level < Scr_LevelManager.maxLevel)
            SceneManager.LoadScene(level + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}