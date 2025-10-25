using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EndPanelUI : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private TMP_Text errorCount;
    
    private void Start()
    {
        RhythmGameManager.Instance.OnLevelEnd += EnableEndPanel;

        panel.SetActive(false);
    }

    private void OnDestroy()
    {
        RhythmGameManager.Instance.OnLevelEnd -= EnableEndPanel;
    }
    private void EnableEndPanel()
    {
        score.text = RhythmGameManager.Instance.GetScore().ToString();
        errorCount.text = "Errors: " + RhythmGameManager.Instance.GetErrorCount().ToString();
        panel.SetActive(true);
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene("BeatMakerSceneTest");
    }


}
