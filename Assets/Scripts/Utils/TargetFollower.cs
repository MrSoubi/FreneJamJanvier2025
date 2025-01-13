using UnityEngine;

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

    // Variables pour le shake
    private bool isShaking = false;
    private float shakeDuration = 1f;
    private float shakeBaseDuration = 1f;
    private float shakeBaseIntensity = 0.5f;
    private float shakeIntensity = 0.5f;
    private Vector3 originalPosition;

    public RSE_BombInteraction bombInteraction;
    private void OnEnable()
    {
        bombInteraction.TriggerEvent += Shake;
    }

    private void OnDisable()
    {
        bombInteraction.TriggerEvent -= Shake;
    }

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

        // Gérer l'effet de shake
        if (isShaking)
        {
            ApplyShake();
        }
    }

    public void Shake()
    {
        shakeIntensity = shakeBaseIntensity;
        shakeDuration = shakeBaseDuration;
        originalPosition = transform.position;
        isShaking = true;
    }

    private void ApplyShake()
    {
        if (shakeDuration > 0)
        {
            // Générer un déplacement aléatoire
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;
            transform.position = target.position + offset + shakeOffset;

            // Réduire la durée et l'intensité
            shakeDuration -= Time.deltaTime;
            shakeIntensity = Mathf.Lerp(shakeIntensity, 0, Time.deltaTime / shakeDuration);
        }
        else
        {
            // Fin du shake
            isShaking = false;
        }
    }
}
