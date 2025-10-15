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
    [Range(0f, 4f)]
    private float hitWindow = 0.9f;
    



    private int currentActiveButton = -1; // -1 = No active buttons
  

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
        float currentBeatValue = RhythmGameManager.Instance.GetBeatTime();

        if (currentBeatValue < hitWindow && currentBeatValue > -hitWindow && currentActiveButton < 0)
        {
            TriggerNewButton();
        }
        else if (currentBeatValue > hitWindow || currentBeatValue < -hitWindow)
        {
            UntriggerButton();
        }
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
        RhythmGameManager.Instance.GetButtonsPressed();
        UntriggerButton();

    }


}
