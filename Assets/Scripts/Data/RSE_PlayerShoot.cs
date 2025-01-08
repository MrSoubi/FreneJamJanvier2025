using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerMoveShoot", menuName = "RSE/PlayerMoveShoot")]
public class RSE_PlayerMoveShoot : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}