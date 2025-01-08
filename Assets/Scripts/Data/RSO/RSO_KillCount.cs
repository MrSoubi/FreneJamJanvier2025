using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KillCount", menuName = "RSO/KillCount")]
public class RSO_KillCount : ScriptableObject, IReactiveSO<int>
{
    public event Action<int> onValueChanged;

    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            if (_value == value) return;

            _value = value;
            onValueChanged?.Invoke(_value);
        }
    }
}
