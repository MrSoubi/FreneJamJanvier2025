using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public RSO_KillCount killCount;

    public override void Die()
    {
        killCount.Value++;
        Destroy(gameObject); // Détruit l'objet
    }
}