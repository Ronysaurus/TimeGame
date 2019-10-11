using UnityEngine;
using UnityEngine.SceneManagement;
using Doozy.Engine.UI;

public class MainMenu : MonoBehaviour
{
    public UIView creditsView, mainView, lelvelView;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainView.Hide();
        creditsView.Show();
    }

    public void Back()
    {
        creditsView.Hide();
        lelvelView.Hide();
        mainView.Show();
    }

    public void LevelSelect()
    {
        mainView.Hide();
        lelvelView.Show();
    }
}