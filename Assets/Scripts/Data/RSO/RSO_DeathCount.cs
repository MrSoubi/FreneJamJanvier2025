using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DeathCount", menuName = "RSO/DeathCount")]
public class RSO_DeathCount : ScriptableObject
{
    public Action<int> onValueChanged;

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