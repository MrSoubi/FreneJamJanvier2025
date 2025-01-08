using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerInteraction", menuName = "RSE/PlayerInteraction")]
public class RSE_PlayerInteraction : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}