using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerMoveRight", menuName = "RSE/PlayerMoveRight")]
public class RSE_PlayerMoveRight : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}