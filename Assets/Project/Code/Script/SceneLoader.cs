using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader _instance { get; private set; }

    [Header("SETUP")]
    [SerializeField]
    private float timeToChargeScene = 3f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadAdditiveScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadWithChargeScene(string nameScene, string nameChargingScene)
    {
        ChangeScene(nameChargingScene);

        StartCoroutine(ChargeScene(nameScene));
    }

    private IEnumerator ChargeScene(string name)
    {
        
        yield return new WaitForSecondsRealtime(timeToChargeScene);

        ChangeScene(name);
    }
}
