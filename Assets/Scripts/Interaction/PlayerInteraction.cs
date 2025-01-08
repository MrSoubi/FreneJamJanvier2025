using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public RSE_PlayerInteraction playerInteraction;

    public float interactionRadius = 1.5f;
    private Interactable currentInteractable;

    void Update()
    {
        // Détection d'interaction
        CheckForInteractable();

        // Interaction avec la touche 'E'
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
            playerInteraction.TriggerEvent?.Invoke();
        }
    }

    private void CheckForInteractable()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        currentInteractable = null;

        foreach (var hit in hits)
        {
            Interactable interactable = hit.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                return; // On s'arrête à la première interaction trouvée
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Affichage de la zone d'interaction dans l'éditeur
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
