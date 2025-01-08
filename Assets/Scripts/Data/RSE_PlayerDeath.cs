using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerDeath", menuName = "RSE/PlayerDeath")]
public class RSE_PlayerDeath : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}