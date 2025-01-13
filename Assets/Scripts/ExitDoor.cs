using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Door
{
    public string levelToLoad;
    public override void Interact()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
