using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }
    

    IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            yield return null;
        }
    }

    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject sceneLoaderGO = new GameObject("SceneLoader");
                instance = sceneLoaderGO.AddComponent<SceneLoader>();
            }
            return instance;
        }
    }
}