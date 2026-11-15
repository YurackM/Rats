using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int sceneNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switch scene using scene name
    public void SwitchSceneByName()
    {
        SceneManager.LoadScene(sceneName);
    }
}
