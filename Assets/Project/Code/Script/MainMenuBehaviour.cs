using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject configPanel;
    [SerializeField]
    private GameObject creditsPanel;
    [SerializeField]
    private GameObject levelSelectorPanel;
    [Header(" -LevelSelection")]
    [SerializeField]
    private TMP_Text lvl1MaxScoreText;
    [SerializeField]
    private TMP_Text lvl2MaxScoreText;

    [Header("AudioMixer")]
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider mainSlider;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private Slider musicSlider;

    private void Start()
    {

        mainMenuPanel.SetActive(true);
        configPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelSelectorPanel.SetActive(false);

        lvl1MaxScoreText.text = "Puntuació Maxima: " + PlayerPrefs.GetInt("lvl1Score", 0).ToString();
        lvl2MaxScoreText.text = "Puntuació Maxima: " + PlayerPrefs.GetInt("lvl2Score", 0).ToString();

        SetVolume();
        SetVolumeMusic();
        SetVolumeSFX();
    }

    public void OnPlay()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelSelectorPanel.SetActive(true);
    }
    public void OnConfig()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(true);
        creditsPanel.SetActive(false);
        levelSelectorPanel.SetActive(false);
    }
    public void OnCredits()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(false);
        creditsPanel.SetActive(true);
        levelSelectorPanel.SetActive(false);
    }
    public void OnBack()
    {
        mainMenuPanel.SetActive(true);
        configPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelSelectorPanel.SetActive(false);
    }

    public void OnPlayLVL1()
    {
        SceneLoader._instance.LoadWithChargeScene("BeatMakerSceneTest", "RockCharge");
    }
    public void OnPlayLVL2()
    {
        SceneLoader._instance.LoadWithChargeScene("BeatMakerSceneLevel2", "FlamencoCharge");
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("VolumeMaster", Mathf.Log10(mainSlider.value) * 20);
    }
    public void SetVolumeSFX()
    {
        audioMixer.SetFloat("VolumeSFX", Mathf.Log10(sfxSlider.value) * 20);
    }
    public void SetVolumeMusic()
    {
        audioMixer.SetFloat("VolumeMusic", Mathf.Log10(musicSlider.value) * 20);
    }
}
