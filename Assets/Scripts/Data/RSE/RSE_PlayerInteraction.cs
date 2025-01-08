using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerInteraction", menuName = "RSE/PlayerInteraction")]
public class RSE_PlayerInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}