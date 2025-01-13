using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public RSO_DeathCount deathCount;
    [SerializeField] PlayerLifeDisplay lifeDisplay;

    public override void Die()
    {
        deathCount.Value++;
        Destroy(gameObject); // Détruit l'objet
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        lifeDisplay.SetDisplay(currentHealth);
    }
}