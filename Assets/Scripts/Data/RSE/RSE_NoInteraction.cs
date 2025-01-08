using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_NoInteraction", menuName = "RSE/NoInteraction")]
public class RSE_NoInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}