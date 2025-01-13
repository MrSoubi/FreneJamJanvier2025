using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_Level1Finished", menuName = "RSE/Level1Finished")]
public class RSE_Level1Finished : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}