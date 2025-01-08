using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerJump", menuName = "RSE/PlayerJump")]
public class RSE_PlayerJump : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}