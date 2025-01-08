using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerWallJump", menuName = "RSE/PlayerWallJump")]
public class RSE_PlayerWallJump : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}