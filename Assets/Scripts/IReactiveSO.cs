using System;

public interface IReactiveSO<T>
{
    event Action<T> onValueChanged; // �v�nement d�clench� lors d�un changement
    T Value { get; set; }           // Propri�t� pour la valeur suivie
}
