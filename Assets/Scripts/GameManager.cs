using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RSE_ChangeScene changeScene;

    string m_currentScene;

    private void OnEnable()
    {
        changeScene.TriggerEvent += ChangeScene;
    }

    private void OnDisable()
    {
        changeScene.TriggerEvent -= ChangeScene;
    }

    void Start()
    {
        m_currentScene = "MainMenu";
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
    }

    async void ChangeScene(string sceneName)
    {
        if (m_currentScene != null)
        {
            await SceneManager.UnloadSceneAsync(m_currentScene);
        }

        m_currentScene = sceneName;

        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}
