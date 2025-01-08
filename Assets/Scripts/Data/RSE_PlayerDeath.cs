using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerDeath", menuName = "RSE/PlayerDeath")]
public class RSE_PlayerDeath : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}