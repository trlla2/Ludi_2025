using UnityEngine;
using UnityEngine.UI;

public class DancingSpeakers : MonoBehaviour
{
    private SpriteRenderer sprite;

    [Header("Animation Settings")]
    [SerializeField]
    private float scaleModifier = 0.1f;
    [SerializeField]
    private bool forceHardDance = false;

    private void Start()
    {
        //sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float currentBeatTime;
        if (forceHardDance)
        {
            currentBeatTime = Mathf.Abs(RhythmGameManager.Instance.GetHardBeatTime());
        }
        else
        {
            currentBeatTime = RhythmGameManager.Instance.GetAbsBeatTime();
        }

        transform.localScale = new Vector3(1, 1.0f + scaleModifier * currentBeatTime, 1);
    }
}
