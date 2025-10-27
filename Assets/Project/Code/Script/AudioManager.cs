using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance { get; private set; }

    [SerializeField] private GameObject audioContainer;
    [SerializeField] private AudioSource[] instrumentsList;

    public UnityEvent OnAllInstrumentsPlaying;

    private int instrumentsPlaying = 0;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(audioContainer);
    }

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
            OnAllInstrumentsPlaying.Invoke();
    }

    public void PauseMusic()
    {
        foreach (AudioSource audio in instrumentsList)
        {
            audio.Pause();
        }
    }

    public void KillAudioManager()
    {
        Destroy(this.gameObject);
    }
}
