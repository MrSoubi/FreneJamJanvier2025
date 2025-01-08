using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerWallJump", menuName = "RSE/PlayerWallJump")]
public class RSE_PlayerWallJump : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}