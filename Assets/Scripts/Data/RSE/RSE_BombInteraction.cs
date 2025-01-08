using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_BombInteraction", menuName = "RSE/BombInteraction")]
public class RSE_BombInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}