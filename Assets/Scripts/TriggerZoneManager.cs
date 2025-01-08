using UnityEngine.Events;
using UnityEngine;

public class TriggerZoneManager : MonoBehaviour
{
    [Header("Trigger Events")]
    public UnityEvent onTriggerEnterEvent; // �v�nement pour l'entr�e dans le trigger
    public UnityEvent onTriggerExitEvent; // �v�nement pour la sortie du trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerExitEvent.Invoke();
        }
    }
}