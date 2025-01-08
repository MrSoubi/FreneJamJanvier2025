using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayTime", menuName = "RSO/PlayTime")]
public class RSO_PlayTime : ScriptableObject, IReactiveSO<float>
{
    public event Action<float> onValueChanged;

    private float _value;

    public float Value
    {
        get => _value;
        set
        {
            if (Mathf.Approximately(_value, value)) return; // Évite les mises à jour inutiles pour les float

            _value = value;
            onValueChanged?.Invoke(_value);
        }
    }
}
