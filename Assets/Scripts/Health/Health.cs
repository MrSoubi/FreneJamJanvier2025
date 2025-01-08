using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public RSO_KillCount killCount;

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
    private void Die()
    {
        killCount.Value++;
        Destroy(gameObject); // Détruit l'objet
    }

    // Méthode optionnelle pour soigner l'objet
    public void Heal(int amount)
    {
        currentHealth += amount;

        // Assure que les PV ne dépassent pas le maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log(gameObject.name + " a été soigné de " + amount + " PV. PV actuels : " + currentHealth);
    }
}