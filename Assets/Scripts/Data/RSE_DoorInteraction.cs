using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_DoorInteraction", menuName = "RSE/DoorInteraction")]
public class RSE_DoorInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}