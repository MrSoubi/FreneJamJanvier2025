using System;

public interface IReactiveSE
{
    event Action TriggerEvent; // �v�nement d�clench�
    void FireEvent();          // M�thode pour d�clencher l��v�nement
}