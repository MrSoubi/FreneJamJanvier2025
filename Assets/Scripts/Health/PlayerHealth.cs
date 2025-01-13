using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public RSO_DeathCount deathCount;
    [SerializeField] PlayerLifeDisplay lifeDisplay;
    [SerializeField] float invicibilityTime = 2f;
    private float lastDamageTime = -1;

    public override void Die()
    {
        deathCount.Value++;
        Destroy(gameObject); // Détruit l'objet
    }

    public override void TakeDamage(int damage)
    {
        if (Time.time < lastDamageTime + invicibilityTime) return;

        base.TakeDamage(damage);
        lastDamageTime = Time.time;
        lifeDisplay.SetDisplay(currentHealth);
    }
}