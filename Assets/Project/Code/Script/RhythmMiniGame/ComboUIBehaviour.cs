using TMPro;
using UnityEngine;

public class ComboUIBehaviour : MonoBehaviour
{
    private TMP_Text tm;

    [Header("SETUP")]
    [SerializeField]
    private ParticleSystem comboParticles;

    [SerializeField]
    private ParticleSystem[] confettis;

    private void Start()
    {
        tm = this.GetComponent<TMP_Text>();
        RhythmGameManager.Instance.OnComboChange += ChangeScore;
    }
    private void ChangeScore(int combo)
    {
        if(combo > 0) 
        {
            tm.text = combo.ToString() + "x";
            comboParticles.Play();

            if(combo >= 6)
            {
                foreach(ParticleSystem c in confettis)
                {
                    c.Play();
                }
            }
        }
        else 
        {
            tm.text = "";
        }
        
    }
    private void OnDestroy()
    {
        RhythmGameManager.Instance.OnComboChange -= ChangeScore;
    }
}
