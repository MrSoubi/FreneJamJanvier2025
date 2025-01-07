using UnityEngine;

// ChatGPT
public class TargetFollower : MonoBehaviour
{
    [Header("Target Settings")]
    [Tooltip("Le Transform de la cible que la caméra doit suivre.")]
    public Transform target;

    [Header("Damping Settings")]
    [Tooltip("Le facteur de damping pour adoucir le mouvement de la caméra.")]
    public float damping = 0.3f;

    [Header("Offset Settings")]
    [Tooltip("Décalage par rapport à la position de la cible.")]
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Vérifie si une cible est assignée
        if (target == null)
        {
            Debug.LogWarning("Aucune cible assignée à la caméra.");
            return;
        }

        // Calcul de la position cible avec offset
        Vector3 targetPosition = target.position + offset;

        // SmoothDamp ajuste la position de la caméra en fonction du damping
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}