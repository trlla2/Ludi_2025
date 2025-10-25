using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GhostButton : MonoBehaviour
{
    private Image img;

    private bool triggerButton = false;
    private void Start()
    {
        img = GetComponent<Image>();
    }


    private void Update()
    {
        if (triggerButton)
        {
            CompasUpdate();
        }
        else
        {
            img.GetComponent<RectTransform>().localScale = Vector3.one;
        }
    }

    private void CompasUpdate()
    {
        float currentBeatTime = RhythmGameManager.Instance.GetAbsBeatTime();

        img.GetComponent<RectTransform>().localScale = Vector3.one * (1.0f + 0.5f * currentBeatTime);

    }


    public void Trigger(bool trigger)
    {
        triggerButton = trigger;
    }
}
