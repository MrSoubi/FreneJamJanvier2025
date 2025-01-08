using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_BombInteraction", menuName = "RSE/BombInteraction")]
public class RSE_BombInteraction : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}