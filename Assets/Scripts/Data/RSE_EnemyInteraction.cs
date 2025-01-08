using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_EnemyInteraction", menuName = "RSE/EnemyInteraction")]
public class RSE_EnemyInteraction : ScriptableObject
{
    public Action TriggerEvent;

    private void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}