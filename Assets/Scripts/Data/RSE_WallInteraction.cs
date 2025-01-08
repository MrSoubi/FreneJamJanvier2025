using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_WallInteraction", menuName = "RSE/WallInteraction")]
public class RSE_WallInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}