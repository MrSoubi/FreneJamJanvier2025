using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_EnemyInteraction", menuName = "RSE/EnemyInteraction")]
public class RSE_EnemyInteraction : ScriptableObject, IReactiveSE
{
    public event Action TriggerEvent;

    public void FireEvent()
    {
        TriggerEvent?.Invoke();
    }
}