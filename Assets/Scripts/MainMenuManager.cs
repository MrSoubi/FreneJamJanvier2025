using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public RSE_ChangeScene changeScene;

    public void Play()
    {
        changeScene.FireEvent("LV1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
