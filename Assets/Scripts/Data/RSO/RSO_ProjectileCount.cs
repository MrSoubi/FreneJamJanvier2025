using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileCount", menuName = "RSO/ProjectileCount")]
public class RSO_ProjectileCount : ScriptableObject
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