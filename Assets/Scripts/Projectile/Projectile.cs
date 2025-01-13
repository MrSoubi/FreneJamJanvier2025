using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [Tooltip("Dur�e de vie du projectile en secondes.")]
    public float lifetime = 5f;

    [Tooltip("D�g�ts inflig�s par le projectile.")]
    public int damage = 10;

    public GameObject sfx;

    void Start()
    {
        // D�truire le projectile apr�s un certain temps
        Instantiate(sfx);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si le projectile entre en collision avec un objet ayant un composant Health
        Health targetHealth = collision.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Inflige des d�g�ts � la cible
            targetHealth.TakeDamage(damage);
        }

        if (collision.GetComponent<Bomb>() != null)
        {
            collision.GetComponent<Bomb>().Interact();
        }

        // D�truit le projectile apr�s la collision
        Destroy(gameObject);
    }
}