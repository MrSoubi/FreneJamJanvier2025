using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_FlyingEnemyKilled", menuName = "RSO/FlyingEnemyKilled")]
public class RSO_FlyingEnemyKilled : ScriptableObject
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