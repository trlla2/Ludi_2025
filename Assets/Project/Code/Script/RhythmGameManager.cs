using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    private static RhythmGameManager instance;
    public static RhythmGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RhythmGameManager();

            }
            return instance;
        }
    }

    


    private RhythmSyncSystem currentRhythmSystem;

    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void RegisterRhythmSystem(RhythmSyncSystem rhythmSystem)
    {
        currentRhythmSystem = rhythmSystem;
        Debug.Log("RhythmSyncSystem registrado en GameManager");
    }

    public void UnregisterRhythmSystem()
    {
        currentRhythmSystem = null;
    }
    public float GetBeatTime() 
    { 
        return currentRhythmSystem.GetBeatTime();
    }

    public float GetAbsBeatTime()
    {
        return currentRhythmSystem.GetAbsBeatTime();
    }

    public void GetButtonsPressed(int points)
    {
        Debug.Log(points + " points added");
    }
}


