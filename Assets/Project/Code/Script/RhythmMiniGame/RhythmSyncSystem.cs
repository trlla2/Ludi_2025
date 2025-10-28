using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class RhythmSyncSystem : MonoBehaviour
{
    [Header("SETTINGS")]
    [SerializeField]
    private float bpm = 120;
    float beatTime = 0;
    float hardBeatTime = 0;

    [SerializeField]
    float initialDelay = 0.0f;

    [SerializeField]
    private bool easyMode = true; 

    [SerializeField]
    private AudioSource musicSource;

    
    private void Start()
    {
        
        beatTime = 60.0f / (bpm * 0.25f); // beats/second

       
        hardBeatTime = 60.0f / (bpm * 0.5f); // beats/second

        if (!easyMode)
            beatTime = hardBeatTime;

        if (RhythmGameManager.Instance != null)
        {
            RhythmGameManager.Instance.RegisterRhythmSystem(this);
        }

        
    }

    private void Update()
    {

        if (musicSource.time >= musicSource.clip.length)
        {
            RhythmGameManager.Instance.SongEnded();
        }
    }

   

    private void OnDestroy()
    {
        if (RhythmGameManager.Instance != null)
        {
            RhythmGameManager.Instance.UnregisterRhythmSystem();
        }
    }
    
    public float GetBeatTime()
    {

        float songTime = musicSource.time + initialDelay;

        float currentBeat = songTime / beatTime;


        float result = Mathf.Sin(currentBeat * 360 * Mathf.Deg2Rad);
        return result;
    }
    public float GetAbsBeatTime()
    {
        return Mathf.Abs(GetBeatTime());
    }

    public float GetHardBeatTime()
    {

        float songTime = musicSource.time + initialDelay;

        float currentBeat = songTime / hardBeatTime;


        float result = Mathf.Sin(currentBeat * 360 * Mathf.Deg2Rad);
        return result;
    }
    public float GetAbsHardBeatTime()
    {
        return Mathf.Abs(GetHardBeatTime());
    }
    public void PauseMusic()
    {

        musicSource.Pause();
    }
    public void StartMusic()
    {

        musicSource.Play();
    }
}
