using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TriggerZoneManager : MonoBehaviour
{
    [Header("Trigger Events")]
    public UnityEvent onTriggerEnterEvent; // �v�nement pour l'entr�e dans le trigger
    public UnityEvent onTriggerExitEvent; // �v�nement pour la sortie du trigger

    // Liste des objets actuellement dans la zone
    private List<GameObject> objectsInZone = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectsInZone.Contains(other.gameObject))
        {
            objectsInZone.Add(other.gameObject);
        }

        // D�clenche l'�v�nement d'entr�e
        onTriggerEnterEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (objectsInZone.Contains(other.gameObject))
        {
            objectsInZone.Remove(other.gameObject);
        }

        // D�clenche l'�v�nement de sortie
        onTriggerExitEvent.Invoke();
    }

    /// <summary>
    /// Retourne une liste des objets actuellement dans la zone de trigger.
    /// </summary>
    /// <returns>Liste des GameObjects dans la zone</returns>
    public List<GameObject> GetObjectsInZone()
    {
        return new List<GameObject>(objectsInZone); // Retourne une copie pour �viter des modifications non d�sir�es
    }
}