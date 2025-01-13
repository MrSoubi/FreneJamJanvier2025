using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : Door
{
    public string levelToLoad;
    public RSE_ChangeScene changeScene;

    public override void Interact()
    {
        changeScene.FireEvent(levelToLoad);
    }
}
