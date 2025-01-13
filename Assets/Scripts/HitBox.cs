using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(TriggerZoneManager))]
public class HitBox : MonoBehaviour
{
    [Header("HurtBox Settings")]
    [Tooltip("Dégâts infligés aux objets avec un composant Health.")]
    public int damage = 10;

    private TriggerZoneManager triggerZoneManager;

    private void Awake()
    {
        // Récupérer le TriggerZoneManager attaché à ce GameObject
        triggerZoneManager = GetComponent<TriggerZoneManager>();
        if (triggerZoneManager == null)
        {
            Debug.LogError("TriggerZoneManager est requis sur le même GameObject.");
        }
    }

    public void ApplyDamage()
    {
        List<GameObject> targets = triggerZoneManager.GetObjectsInZone();

        // Parcourir tous les objets actuellement dans la zone
        // Parcours inverse car les éléments peuvent être détruits après l'application des dégâts
        for (int i = targets.Count - 1; i >= 0; i--)
        {
            EnemyHealth targetHealth;
            Bomb targetBomb;

            if (targets[i].TryGetComponent<EnemyHealth>(out targetHealth))
            {
                targetHealth.TakeDamage(damage);
            }
            else if (targets[i].TryGetComponent<Bomb>(out targetBomb))
            {
                targetBomb.Interact();
            }
        }
    }
}
