using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_ChangeScene", menuName = "RSE/ChangeScene")]
public class RSE_ChangeScene : ScriptableObject
{
    public event Action<String> TriggerEvent;

    public void FireEvent(String levelToLoad)
    {
        TriggerEvent?.Invoke(levelToLoad);
    }
}