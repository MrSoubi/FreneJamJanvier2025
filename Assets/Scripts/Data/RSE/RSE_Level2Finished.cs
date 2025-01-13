using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_Level2Finished", menuName = "RSE/Level2Finished")]
public class RSE_Level2Finished : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}