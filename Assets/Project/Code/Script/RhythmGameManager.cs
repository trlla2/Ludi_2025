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
    private int excellentPoints = 100;
    [SerializeField]
    private int greatPoints = 50;
    [SerializeField]
    private int goodPoints = 20;

    private int score = 0;

    public delegate void GetButtonHit(int acuracy);// 0 = bad, 1 = good, 2 = great, 3 = excellent
    public event GetButtonHit OnButtonHit;

    public delegate void GetScoreChange(int s);
    public event GetScoreChange OnScoreChange;

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
        
        if (GetBeatTime() < excellentWindow && GetBeatTime() > -excellentWindow)
        {
            score += excellentPoints;
            OnButtonHit?.Invoke(3);
            OnScoreChange?.Invoke(score);
        }
        else if (GetBeatTime() < greatWindow && GetBeatTime() > -greatWindow)
        {
            score += greatPoints;
            OnButtonHit?.Invoke(2);
            OnScoreChange?.Invoke(score);
        }
        else if (GetBeatTime() < goodWindow && GetBeatTime() > -goodWindow)
        {
            score += goodPoints;
            OnButtonHit?.Invoke(1);
            OnScoreChange?.Invoke(score);
        }
        else
        {
            OnButtonHit?.Invoke(0);
        }
        Debug.Log("Score " + score);
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

    public void SongEnded()
    {
        if(PlayerPrefs.GetInt("lvl1Score",0) < score)
        {
            PlayerPrefs.SetInt("lvl1Score", score);
        }
        Application.Quit();
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


