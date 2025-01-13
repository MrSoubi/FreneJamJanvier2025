using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_BombCount", menuName = "RSO/BombCount")]
public class RSO_BombCount : ScriptableObject
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