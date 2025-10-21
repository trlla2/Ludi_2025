using UnityEngine;
using UnityEngine.Audio;
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

    [Header("AudioMixer")]
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private Slider mainSlider;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private Slider musicSlider;

    public void OnPlay()
    {

    }
    public void OnConfig()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void IOnCredits()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void OnBack()
    {
        mainMenuPanel.SetActive(true);
        configPanel.SetActive(false);
        creditsPanel.SetActive(false);
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
