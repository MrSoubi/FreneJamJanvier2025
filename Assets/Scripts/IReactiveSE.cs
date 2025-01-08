using System;

public interface IReactiveSE
{
    event Action TriggerEvent; // Événement déclenché
    void FireEvent();          // Méthode pour déclencher l’événement
}