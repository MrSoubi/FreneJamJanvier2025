using UnityEngine;

public class FlipSpriteByVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; // Référence au Rigidbody2D
    [SerializeField] private SpriteRenderer spriteRenderer; // Référence au SpriteRenderer

    [Header("Configuration")]
    [Tooltip("Inverse le sens du flip")]
    public bool reverse = false; // Permet d'inverser le sens de flip

    void Start()
    {
        // Vérifier si les références sont assignées dans l'inspecteur
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D non assigné sur " + gameObject.name);
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer non assigné sur " + gameObject.name);
        }
    }

    void Update()
    {
        if (rb == null || spriteRenderer == null) return;

        // Déterminer si le sprite doit être flippé
        bool shouldFlip = rb.linearVelocity.x < 0;

        // Inverser le sens du flip si reverse est activé
        spriteRenderer.flipX = reverse ? !shouldFlip : shouldFlip;
    }
}
