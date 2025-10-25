using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class ScoreBehaviour : MonoBehaviour
{
    private TMP_Text tm;

    [Header("SETUP")]
    [SerializeField]
    private ParticleSystem scoreParticles;

    private void Start()
    {
        tm = this.GetComponent<TMP_Text>();
        RhythmGameManager.Instance.OnScoreChange += ChangeScore;
    }
    private void ChangeScore(int score)
    {
       tm.text = score.ToString();
       scoreParticles.Play();
    }
    private void OnDestroy()
    {
        RhythmGameManager.Instance.OnScoreChange -= ChangeScore;
    }
}
