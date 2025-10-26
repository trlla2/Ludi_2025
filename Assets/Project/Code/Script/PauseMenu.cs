using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField]
    private GameObject pausePanel;

    private bool pause = false;

    private void Start()
    {
        DisablePause();
    }

    private void EnablePause()
    {
        pause = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0;

    }
    private void DisablePause()
    {
        pause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnPauseButton()
    {
        if (pause)
        {
            DisablePause();
        }
        else
        {
            EnablePause();
        }
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBackButton()
    {
        DisablePause();
    }

}
