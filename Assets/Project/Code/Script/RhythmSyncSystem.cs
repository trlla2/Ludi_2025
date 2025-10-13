using UnityEngine;

public class RhythmSyncSystem : MonoBehaviour
{
    [Header("SETTINGS")]
    [SerializeField]
    private int bpm = 120;
    float beatTime = 0;

    [SerializeField]
    private bool isMp3 = false;
    float initialDelay = 0.1f;

    [SerializeField]
    private AudioSource musicSource;


    private void Start()
    {
        beatTime = 60.0f / bpm; // beats * second
    }

    private float GetBeatTime()
    {
        float songTime = musicSource.time;

        float currentBeat = songTime / beatTime;


        float result = Mathf.Sin(currentBeat * 360 * Mathf.Deg2Rad);
        return result;
    }

    private void Update()
    {
        Debug.Log("Beat Time: " + GetBeatTime());
    }
}
