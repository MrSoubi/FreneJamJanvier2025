using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TotalWalkDistance", menuName = "RSO/TotalWalkDistance")]
public class RSO_TotalWalkDistance : ScriptableObject
{
    public Action<float> onValueChanged;

    private float _value;

    public float Value
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