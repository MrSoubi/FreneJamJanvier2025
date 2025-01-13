using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public RSO_KillCount killCount;
    public GameObject deathAnimation;

    public override void Die()
    {
        killCount.Value++;
        if (deathAnimation != null)
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); // Détruit l'objet
    }
}