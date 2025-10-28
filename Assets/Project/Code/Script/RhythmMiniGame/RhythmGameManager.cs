using JetBrains.Annotations;
using Unity.Burst.Intrinsics;
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
    [SerializeField]
    [Range(2, 20)]
    private int minCombo = 4;
    private int currentCombo = 0;

    [Header("Points")]
    [SerializeField]
    private int excellentPoints = 100;
    [SerializeField]
    private int greatPoints = 50;
    [SerializeField]
    private int goodPoints = 20;

    private int score = 0;

    private int errorCounter = 0;

    public delegate void GetButtonHit(int acuracy);// 0 = bad, 1 = good, 2 = great, 3 = excellent
    public event GetButtonHit OnButtonHit;

    public delegate void GetScoreChange(int s);
    public event GetScoreChange OnScoreChange;

    public delegate void GetComboChange(int c);
    public event GetComboChange OnComboChange;

    public delegate void GetEndLevel();
    public event GetEndLevel OnLevelEnd;

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
        Debug.Log("RhythmSyncSystem registred");
    }

    public void UnregisterRhythmSystem()
    {
        currentRhythmSystem = null;
    }

    public void ButtonsPressed()
    {
        
        if (GetBeatTime() < excellentWindow && GetBeatTime() > -excellentWindow)
        {
            currentCombo++;
            score += excellentPoints * currentCombo;
            OnButtonHit?.Invoke(3);
            OnComboChange?.Invoke(currentCombo);
            OnScoreChange?.Invoke(score);
        }
        else if (GetBeatTime() < greatWindow && GetBeatTime() > -greatWindow)
        {
            currentCombo++;
            score += greatPoints * currentCombo;
            OnButtonHit?.Invoke(2);
            OnComboChange?.Invoke(currentCombo);
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
            currentCombo = 0;

            OnComboChange?.Invoke(currentCombo);
            OnButtonHit?.Invoke(0);
            errorCounter++;
        }
        Debug.Log("Score " + score);
    }

    public void AddError()
    {
        currentCombo = 0;
        OnComboChange?.Invoke(currentCombo);
        OnButtonHit?.Invoke(0);
        errorCounter++;
    }

    public void SongEnded()
    {
        if(PlayerPrefs.GetInt("lvl1Score",0) < score)
        {
            PlayerPrefs.SetInt("lvl1Score", score);
        }


        OnLevelEnd.Invoke();

        score = 0;
        errorCounter = 0;
    }

    public void PauseSyncMusic() { currentRhythmSystem?.PauseMusic();  }
    public void StartSyncMusic() { currentRhythmSystem?.StartMusic();  }
    public float GetBeatTime()  {  
        if(currentCombo < minCombo)
            return currentRhythmSystem.GetBeatTime();
        else
            return currentRhythmSystem.GetHardBeatTime();
    }
    public float GetAbsBeatTime() {
        if (currentCombo < minCombo)
            return currentRhythmSystem.GetAbsBeatTime();
        else
            return currentRhythmSystem.GetAbsHardBeatTime();
    }

    public float GetHardBeatTime() { return currentRhythmSystem.GetHardBeatTime(); }
    public float GetExcelentWindowTime() { return excellentWindow; }
    public float GetGreatWindowTime() { return greatWindow; }
    public float GetGoodWindowTime() { return goodWindow; }
    
    public int GetErrorCount() { return errorCounter; }

    public int GetScore() { return score; }
    
}


