using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("Points de vie maximum de l'objet.")]
    public int maxHealth = 100;

    private int currentHealth;

    public UnityEvent<int> onTakeDamage;
    
    void Start()
    {
        // Initialise les points de vie � leur maximum au d�but
        currentHealth = maxHealth;
    }

    // Appel� pour infliger des d�g�ts � l'objet
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onTakeDamage.Invoke(damage);

        // V�rifie si les points de vie tombent � z�ro ou en dessous
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fonction appel�e lorsque les points de vie atteignent z�ro
    public abstract void Die();
}