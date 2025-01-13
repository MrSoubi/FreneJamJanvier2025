using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_WallJumpCount", menuName = "RSO/WallJumpCount")]
public class RSO_WallJumpCount : ScriptableObject
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