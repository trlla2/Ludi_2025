using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    

    private bool buttonPressed = false;

    private int currentActiveButton = -1; // -1 = No active buttons
  

    private void Start()
    {
        foreach(Button b in rhythmButtons)
        {
            b.interactable = false;
            b.onClick.AddListener(ButtonDown);

        }
    }

    private void Update()
    {
        DetectBeat();

        InputKeyboardUpdate();
    }
    
    private void DetectBeat()
    {
        float currentBeatValue = RhythmGameManager.Instance.GetBeatTime();

        if (currentBeatValue < hitWindow && currentBeatValue > -hitWindow && currentActiveButton < 0 && !buttonPressed)
        {
            TriggerNewButton();
        }
        else if (currentBeatValue > hitWindow || currentBeatValue < -hitWindow)
        {
            UntriggerButton();
            buttonPressed = false;
        }
    }

    private void InputKeyboardUpdate()
    {
        switch (currentActiveButton) {
            case 0:
                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ButtonDown();
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    ButtonDown();
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    ButtonDown();
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ButtonDown();
                }
                break;
            default:
                break;
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

    private void ButtonDown()
    {
        buttonPressed = true;
     
        RhythmGameManager.Instance.ButtonsPressed();
        
        UntriggerButton();
    }

    private void OnDestroy()
    {
        foreach (Button b in rhythmButtons)
        {
            b.interactable = false;
            b.onClick.RemoveListener(ButtonDown);

        }
    }
}
