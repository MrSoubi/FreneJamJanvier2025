using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [Tooltip("Durée de vie du projectile en secondes.")]
    public float lifetime = 5f;

    [Tooltip("Dégâts infligés par le projectile.")]
    public int damage = 10;

    void Start()
    {
        // Détruire le projectile après un certain temps
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si le projectile entre en collision avec un objet ayant un composant Health
        Health targetHealth = collision.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Inflige des dégâts à la cible
            targetHealth.TakeDamage(damage);
        }

        // Détruit le projectile après la collision
        Destroy(gameObject);
    }
}