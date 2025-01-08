using System;

public interface IReactiveSO<T>
{
    event Action<T> onValueChanged; // Événement déclenché lors d’un changement
    T Value { get; set; }           // Propriété pour la valeur suivie
}
