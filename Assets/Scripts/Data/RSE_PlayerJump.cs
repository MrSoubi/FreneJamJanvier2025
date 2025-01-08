using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerJump", menuName = "RSE/PlayerJump")]
public class RSE_PlayerJump : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}