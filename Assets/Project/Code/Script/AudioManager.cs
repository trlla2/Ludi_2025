using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance { get; private set; }

    [SerializeField] private GameObject audioContainer;
    [SerializeField] private AudioSource[] instrumentsList;
    [SerializeField] private string rhythmScene;
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

    public void StartPlaying()
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
        {
            OnAllInstrumentsPlaying?.Invoke();
            SceneLoader._instance?.ChangeScene(rhythmScene);
        }
    }

    public void PauseMusic()
    {
        foreach (AudioSource audio in instrumentsList)
        {
            audio.Pause();
        }
    }

    public AudioSource GetMetronom()
    {
        AudioSource metronom = null;
        foreach (AudioSource audio in instrumentsList)
        {
            if(audio.gameObject.name == "metronomo")
            {
                metronom = audio;
            }
        }
        return metronom;

    }

    public void KillAudioManager()
    {
        instrumentsPlaying = 0;
        Destroy(this.gameObject);
    }
}
