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
        // Initialise les points de vie à leur maximum au début
        currentHealth = maxHealth;
    }

    // Appelé pour infliger des dégâts à l'objet
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onTakeDamage.Invoke(damage);

        // Vérifie si les points de vie tombent à zéro ou en dessous
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fonction appelée lorsque les points de vie atteignent zéro
    public abstract void Die();
}