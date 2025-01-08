using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayTime", menuName = "RSO/PlayTime")]
public class RSO_PlayTime : ScriptableObject
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