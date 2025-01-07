using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("Points de vie maximum de l'objet.")]
    public int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        // Initialise les points de vie � leur maximum au d�but
        currentHealth = maxHealth;
    }

    // Appel� pour infliger des d�g�ts � l'objet
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " a subi " + damage + " d�g�ts. PV restants : " + currentHealth);

        // V�rifie si les points de vie tombent � z�ro ou en dessous
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Fonction appel�e lorsque les points de vie atteignent z�ro
    private void Die()
    {
        Debug.Log(gameObject.name + " est d�truit.");
        Destroy(gameObject); // D�truit l'objet
    }

    // M�thode optionnelle pour soigner l'objet
    public void Heal(int amount)
    {
        currentHealth += amount;

        // Assure que les PV ne d�passent pas le maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log(gameObject.name + " a �t� soign� de " + amount + " PV. PV actuels : " + currentHealth);
    }
}