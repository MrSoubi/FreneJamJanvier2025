using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(TriggerZoneManager))]
public class HitBox : MonoBehaviour
{
    [Header("HurtBox Settings")]
    [Tooltip("Dégâts infligés aux objets avec un composant Health.")]
    public int damage = 10;

    private TriggerZoneManager triggerZoneManager;
    private List<GameObject> objectsInZone = new List<GameObject>();

    private void Awake()
    {
        // Récupérer le TriggerZoneManager attaché à ce GameObject
        triggerZoneManager = GetComponent<TriggerZoneManager>();
        if (triggerZoneManager == null)
        {
            Debug.LogError("TriggerZoneManager est requis sur le même GameObject.");
        }
    }

    private void OnEnable()
    {
        // S'abonner aux événements de TriggerZoneManager
        triggerZoneManager.onTriggerEnterEvent.AddListener(OnObjectEnter);
        triggerZoneManager.onTriggerExitEvent.AddListener(OnObjectExit);
    }

    private void OnDisable()
    {
        // Se désabonner des événements pour éviter les fuites de mémoire
        triggerZoneManager.onTriggerEnterEvent.RemoveListener(OnObjectEnter);
        triggerZoneManager.onTriggerExitEvent.RemoveListener(OnObjectExit);
    }

    private void OnObjectEnter()
    {
        // Ajouter les objets dans la zone au stockage local
        foreach (var obj in triggerZoneManager.GetObjectsInZone())
        {
            if (!objectsInZone.Contains(obj))
            {
                objectsInZone.Add(obj);
            }
        }
    }

    private void OnObjectExit()
    {
        // Supprimer les objets sortant de la zone
        objectsInZone.RemoveAll(obj => !triggerZoneManager.GetObjectsInZone().Contains(obj));
    }

    public void ApplyDamage()
    {
        // Parcourir tous les objets actuellement dans la zone
        // Parcours inverse car les éléments peuvent être détruits après l'application des dégâts
        for (int i = objectsInZone.Count - 1; i >= 0; i--)
        {
            Health targetHealth = objectsInZone[i].GetComponent<Health>();
            if (targetHealth != null)
            {
                // Infliger des dégâts à chaque objet avec un composant Health
                targetHealth.TakeDamage(damage);
            }
        }
    }
}
