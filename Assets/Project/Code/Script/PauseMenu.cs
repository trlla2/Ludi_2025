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
        RhythmGameManager.Instance.PauseSyncMusic();
        AudioManager._instance.PauseMusic();
    }
    private void DisablePause()
    {
        pause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        RhythmGameManager.Instance.StartSyncMusic();
        AudioManager._instance.StartPlaying();
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
        DisablePause();
        AudioManager._instance.StopMusic();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnBackButton()
    {
        DisablePause();
    }

}
