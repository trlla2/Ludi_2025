using UnityEngine;
using UnityEngine.UI;

public class DancingScript : MonoBehaviour
{
    private Image img;

    [Header("Animation Settings")]
    [SerializeField]
    private float scaleModifier = 0.1f;
    [SerializeField]
    private bool forceHardDance = false;

    private void Start()
    {
        img = GetComponent<Image>();
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

        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1.0f + scaleModifier * currentBeatTime,1);
    }

}
