using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_Level4Finished", menuName = "RSE/Level4Finished")]
public class RSE_Level4Finished : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}