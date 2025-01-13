using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LV1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
