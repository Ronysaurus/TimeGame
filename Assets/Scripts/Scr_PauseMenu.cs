using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_PauseMenu : MonoBehaviour
{
    public static bool isPause = false;
    public GameObject pauseMenu;

    public void Pause()
    {
        isPause = !isPause;
        pauseMenu.SetActive(isPause);
    }

    public void Restart()
    {
        isPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        isPause = false;
        SceneManager.LoadScene(0);
    }
}