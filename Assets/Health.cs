using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("Points de vie maximum de l'objet.")]
    public int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        // Initialise les points de vie à leur maximum au début
        currentHealth = maxHealth;
    }

    // Appelé pour infliger des dégâts à l'objet
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " a subi " + damage + " dégâts. PV restants : " + currentHealth);

        // Vérifie si les points de vie tombent à zéro ou en dessous
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fonction appelée lorsque les points de vie atteignent zéro
    private void Die()
    {
        Debug.Log(gameObject.name + " est détruit.");
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