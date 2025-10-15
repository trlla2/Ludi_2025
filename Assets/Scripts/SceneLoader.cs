using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader _instance { get; private set; }

    private void Awake()
    {
        if (_instance != null)
        {
            DontDestroyOnLoad(this.gameObject);
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
