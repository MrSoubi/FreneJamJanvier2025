using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_WallInteraction", menuName = "RSE/WallInteraction")]
public class RSE_WallInteraction : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}