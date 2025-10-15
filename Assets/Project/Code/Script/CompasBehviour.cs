using UnityEngine;
using UnityEngine.UI;

public class CompasBehviour : MonoBehaviour
{
    private Image img;
    [Header("Setup")]
    [SerializeField]
    private Color idle;
    [SerializeField]
    private Color beatHit;

    [SerializeField]
    [Range(0f,1f)]
    private float hitDuration = 0.6f;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.GetComponent<RectTransform>().localScale = Vector3.one * (1.0f + 0.5f * RhythmGameManager.Instance.GetAbsBeatTime());

        if(RhythmGameManager.Instance.GetAbsBeatTime() < hitDuration && RhythmGameManager.Instance.GetAbsBeatTime() > -hitDuration)
        {
            img.color = beatHit;
        }
        else
        {
            img.color = idle;
        }
        
        
    }
}
