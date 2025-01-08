using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerShoot", menuName = "RSE/PlayerShoot")]
public class RSE_PlayerShoot : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}