using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
public class TextHitBehaviour : MonoBehaviour
{
    private RectTransform rectTransform;
    private TMP_Text tm;

    [Header("SETUP")]
    [SerializeField]
    [Range(0f, 5f)]
    private float timeToDisapearText = 1f;
    private float currentTimerToDisapear = 0;
    [SerializeField]
    private ParticleSystem excellentParticles;

    [Header("Hit color")]
    [SerializeField]
    private Color excellentHit;
    [SerializeField]
    private Color greatHit;
    [SerializeField]
    private Color goodHit;
    [SerializeField]
    private Color badHit;

    [Header("Animation")]
    [SerializeField] private float animationDuration = .4f;
    [SerializeField] private float currentAnimationTime = 0f;
    [SerializeField] 
    private AnimationCurve curve = AnimationCurve.Linear(0,0,1,1);
    [SerializeField]
    private Vector3 scale = Vector3.zero;
    private Vector3 originScale;

    private Coroutine currentAnimation;

    private void Start()
    {
        tm = GetComponent<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        RhythmGameManager.Instance.OnButtonHit += ChangeText;

        originScale = rectTransform.localScale;
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
                tm.text = "Malament";
                tm.color = badHit;
                break;
            case 1:
                tm.text = "Bé";
                tm.color = goodHit;
                break;
            case 2:
                tm.text = "Molt Bé";
                tm.color = greatHit;
                break;
            case 3:
                tm.text = "Excelent";
                tm.color = excellentHit;
                excellentParticles.Play();
                break;
        }
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimationTime = 0f;
            rectTransform.localScale = originScale;
        }

        currentAnimation = StartCoroutine(TriggerAnimation());

        currentTimerToDisapear = timeToDisapearText;
    }
    private void OnDestroy()
    {
        RhythmGameManager.Instance.OnButtonHit -= ChangeText;
    }

    private IEnumerator TriggerAnimation()
    {
        while (currentAnimationTime < animationDuration)
        {
            currentAnimationTime += Time.deltaTime;

            SetScaleForCurrentTime();

            yield return null;
        }

        currentAnimationTime = 0f;
        
        rectTransform.localScale = originScale;

        currentAnimation = null;
    }

    private void SetScaleForCurrentTime()
    {
        float interpolatedValue = currentAnimationTime / animationDuration;
        interpolatedValue = curve.Evaluate(interpolatedValue);
        rectTransform.localScale = originScale + (scale * interpolatedValue);
    }
}
