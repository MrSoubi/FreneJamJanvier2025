using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerMoveLeft", menuName = "RSE/PlayerMoveLeft")]
public class RSE_PlayerMoveLeft : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}