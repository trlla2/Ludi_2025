using UnityEngine;
using UnityEngine.UIElements;

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
    [Header("SETUP")]
    
    [SerializeField]
    [Range(0f, 1f)]
    private float excellentWindow = 0.2f;
    [SerializeField]
    [Range(0f, 1f)]
    private float greatWindow = 0.5f;
    [SerializeField]
    [Range(0f, 1f)]
    private float goodWindow = 0.7f;

    [Header("Points")]
    [SerializeField]
    private uint excellentPoints = 100;
    [SerializeField]
    private uint greatPoints = 50;
    [SerializeField]
    private uint goodPoints = 20;

    private int score = 0;


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

    public void ButtonsPressed()
    {
        Debug.Log(GetBeatTime());
        if (GetBeatTime() < excellentWindow && GetBeatTime() > -excellentWindow)
        {
            Debug.Log("Excellent");
        }
        else if (GetBeatTime() < greatWindow && GetBeatTime() > -greatWindow)
        {
            Debug.Log("Great");
        }
        else if (GetBeatTime() < goodWindow && GetBeatTime() > -goodWindow)
        {
            Debug.Log("Good");
        }
        else
        {
            Debug.Log("BaD");
        }
    }

    public void RegisterRhythmSystem(RhythmSyncSystem rhythmSystem)
    {
        currentRhythmSystem = rhythmSystem;
        Debug.Log("RhythmSyncSystem registred");
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
    public float GetExcelentWindowTime()
    {
        return excellentWindow;
    }
    public float GetGreatWindowTime()
    {
        return greatWindow;
    }
    public float GetGoodWindowTime()
    {
        return goodWindow;
    }
    

    
}


