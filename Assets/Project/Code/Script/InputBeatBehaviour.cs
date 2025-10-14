using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputBeatBehaviour : MonoBehaviour
{

    [Header("SETUP")]
    [Header("Buttons")]
    [SerializeField]
    private List<Button> rhythmButtons = new List<Button>(4);

    [Header("Timing Config")]
    [SerializeField]
    [Range(0f, 1f)]
    private float hitWindow = 0.98f;


    private float beatDetectionThreshold = 0.1f;
    private int currentActiveButton = -1; // -1 = No active buttons
    private float lastBeatValue = 0f;
    private bool beatTriggered = false;

    private void Start()
    {
        foreach(Button b in rhythmButtons)
        {
            b.interactable = false;
            b.onClick.AddListener(OnButtonClick);

        }
    }

    private void Update()
    {
        DetectBeat();
    }
    private void OnDestroy()
    {
        foreach (Button b in rhythmButtons)
        {
            b.interactable = false;
            b.onClick.RemoveListener(OnButtonClick);

        }
    }
    private void DetectBeat()
    {
        float currentBeatValue = RhythmGameManager.Instance.GetAbsBeatTime();

        if (lastBeatValue > beatDetectionThreshold && currentBeatValue <= beatDetectionThreshold && !beatTriggered)
        {
            Debug.Log("NewBeat");
            TriggerNewButton();
            beatTriggered = true;
        }

        if(currentBeatValue > hitWindow)
        {
            UntriggerButton();
        }

        if (currentBeatValue > 0.5f)
        {
            beatTriggered = false;
        }

        lastBeatValue = currentBeatValue;
    }

    private void TriggerNewButton()
    {
        UntriggerButton();

        currentActiveButton = Random.Range(0, rhythmButtons.Count);

        rhythmButtons[currentActiveButton].interactable = true;
    }


    private void UntriggerButton()
    {
        if (currentActiveButton >= 0)
        {
            rhythmButtons[currentActiveButton].interactable = false;
            currentActiveButton = -1;

        }
    }

    private void OnButtonClick()
    {
        Debug.Log("Clicked");
        RhythmGameManager.Instance.GetButtonsPressed(20);
    }
    

}
