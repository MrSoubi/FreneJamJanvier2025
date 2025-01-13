using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RSE_ChangeScene changeScene;
    public RSE_PlayerDeath playerDeath;

    public TextMeshProUGUI starterCounter;

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
        starterCounter.enabled = true;
        await SceneManager.UnloadSceneAsync(m_currentScene);
        starterCounter.text = "3";
        await Task.Delay(1000);
        starterCounter.text = "2";
        await Task.Delay(1000);
        starterCounter.text = "1";
        await Task.Delay(1000);
        starterCounter.text = "";
        starterCounter.enabled = false;
        await SceneManager.LoadSceneAsync(m_currentScene, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(m_currentScene));
    }
}
