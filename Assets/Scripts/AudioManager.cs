using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance;

    [SerializeField] private GameObject audioContainer;
    [SerializeField] private AudioSource[] instrumentsList;

    public UnityEvent OnAllInstrumentsPlaying;

    private int instrumentsPlaying = 0;

    void Start()
    {
        instrumentsList = audioContainer.GetComponentsInChildren<AudioSource>();
    }

    private void StartPlaying()
    {
        foreach (AudioSource audio in instrumentsList)
        {
            audio.Play();
        }
    }

    public void PlayInstrument(AudioSource audio)
    {
        if (!audio.isPlaying)
            StartPlaying();

        audio.mute = false;
        instrumentsPlaying++;

        if (instrumentsPlaying >= 4)
            Debug.Log("All Instruments Playing");
            //OnAllInstrumentsPlaying.Invoke();
    }
}
