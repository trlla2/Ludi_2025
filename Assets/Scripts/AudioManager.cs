using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance;

    [SerializeField] private GameObject audioContainer;
    [SerializeField] private AudioSource[] instrumentsList;

    /*private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }*/

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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
