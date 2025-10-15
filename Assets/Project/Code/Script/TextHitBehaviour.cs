using UnityEngine;
using TMPro;
public class TextHitBehaviour : MonoBehaviour
{

    private TMP_Text tm;
    [SerializeField]
    [Range(0f,5f)]
    private float timeToDisapearText = 1f;
    private float currentTimerToDisapear = 0;
    private void Start()
    {
        tm = this.GetComponent<TMP_Text>();
        RhythmGameManager.Instance.OnButtonHit += ChangeText;
    }

    private void Update()
    {
        if (currentTimerToDisapear > 0)
        {
            currentTimerToDisapear -= Time.deltaTime;
        }
        else
        {
            tm.text = "";
        }
    }

    private void ChangeText(int acuracy)
    {
        switch (acuracy)
        {
            case 0:
                tm.text = "Bad";
                break;
            case 1:
                tm.text = "Good";
                break;
            case 2:
                tm.text = "Great";
                break;
            case 3:
                tm.text = "Excellent";
                break;
        }
        currentTimerToDisapear = timeToDisapearText;
    }
    private void OnDestroy()
    {
        RhythmGameManager.Instance.OnButtonHit -= ChangeText;
    }

}
