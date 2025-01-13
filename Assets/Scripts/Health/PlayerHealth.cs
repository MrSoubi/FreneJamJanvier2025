using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public RSO_DeathCount deathCount;

    public override void Die()
    {
        deathCount.Value++;
        Destroy(gameObject); // Détruit l'objet
    }
}