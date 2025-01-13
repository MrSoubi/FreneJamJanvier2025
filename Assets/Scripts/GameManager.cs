using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RSE_ChangeScene changeScene;
    public RSE_PlayerDeath playerDeath;

    public TextMeshProUGUI deathMessage;

    string m_currentScene;

    private void OnEnable()
    {
        changeScene.TriggerEvent += ChangeScene;
        playerDeath.TriggerEvent += ReloadScene;
    }

    private void OnDisable()
    {
        changeScene.TriggerEvent -= ChangeScene;
        playerDeath.TriggerEvent -= ReloadScene;
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

    async void ReloadScene()
    {
        deathMessage.enabled = true;
        await SceneManager.UnloadSceneAsync(m_currentScene);
        await Task.Delay(1000);
        await Task.Delay(1000);
        await Task.Delay(1000);
        await SceneManager.LoadSceneAsync(m_currentScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(m_currentScene));
        deathMessage.enabled = false;
    }
}
