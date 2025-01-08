using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerMoveLeft", menuName = "RSE/PlayerMoveLeft")]
public class RSE_PlayerMoveLeft : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}