using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_Level3Finished", menuName = "RSE/Level3Finished")]
public class RSE_Level3Finished : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}