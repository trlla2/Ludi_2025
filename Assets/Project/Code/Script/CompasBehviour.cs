using UnityEngine;
using UnityEngine.UI;

public class CompasBehviour : MonoBehaviour
{
    private Image img;
    [Header("Setup")]
    [SerializeField]
    private Color idle;
    [SerializeField]
    private Color excellentHit;
    [SerializeField]
    private Color greatHit;
    [SerializeField]
    private Color goodHit;

    
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentBeatTime = RhythmGameManager.Instance.GetAbsBeatTime();

        img.GetComponent<RectTransform>().localScale = Vector3.one * (1.0f + 0.5f * currentBeatTime);

        if(currentBeatTime < RhythmGameManager.Instance.GetExcelentWindowTime() && currentBeatTime > -RhythmGameManager.Instance.GetExcelentWindowTime())
        {
            img.color = excellentHit;
        }
        else if(currentBeatTime < RhythmGameManager.Instance.GetGreatWindowTime() && currentBeatTime > -RhythmGameManager.Instance.GetGreatWindowTime())
        {
            img.color = greatHit;
        }
        else if(currentBeatTime < RhythmGameManager.Instance.GetGoodWindowTime() && currentBeatTime > -RhythmGameManager.Instance.GetGoodWindowTime())
        {
            img.color = goodHit;
        }
        else
        {
            img.color = idle;
        }
        
        
    }
}
