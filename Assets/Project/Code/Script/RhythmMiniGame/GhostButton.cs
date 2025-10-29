using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GhostButton : MonoBehaviour
{
    private Image img;

    private bool triggerButton = false;

    private Vector3 ogScale = Vector3.one;  
    private void Start()
    {
        img = GetComponent<Image>();

        ogScale = transform.localScale;
    }


    private void Update()
    {
        if (triggerButton)
        {
            CompasUpdate();
        }
        else
        {
            img.GetComponent<RectTransform>().localScale = ogScale;
        }
    }

    private void CompasUpdate()
    {
        float currentBeatTime = RhythmGameManager.Instance.GetAbsBeatTime();

        img.GetComponent<RectTransform>().localScale = ogScale * (1.0f + 0.5f * currentBeatTime);

    }


    public void Trigger(bool trigger)
    {
        triggerButton = trigger;
    }
}
