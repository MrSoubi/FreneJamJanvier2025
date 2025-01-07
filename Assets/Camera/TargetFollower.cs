using UnityEngine;

// ChatGPT
public class TargetFollower : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("Le Transform de la cible que la cam�ra doit suivre.")]
    public Transform target;

    [Header("Damping Settings")]
    [Tooltip("Le facteur de damping pour adoucir le mouvement de la cam�ra.")]
    public float damping = 0.3f;

    [Header("Offset Settings")]
    [Tooltip("D�calage par rapport � la position de la cible.")]
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // V�rifie si une cible est assign�e
        if (target == null)
        {
            Debug.LogWarning("Aucune cible assign�e � la cam�ra.");
            return;
        }

        // Calcul de la position cible avec offset
        Vector3 targetPosition = target.position + offset;

        // SmoothDamp ajuste la position de la cam�ra en fonction du damping
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}