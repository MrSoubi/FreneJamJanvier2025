using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_DoorInteraction", menuName = "RSE/DoorInteraction")]
public class RSE_DoorInteraction : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}