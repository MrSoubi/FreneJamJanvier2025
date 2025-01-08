using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerMoveRight", menuName = "RSE/PlayerMoveRight")]
public class RSE_PlayerMoveRight : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}