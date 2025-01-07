using UnityEngine;

public class FlipSpriteTowardsMouse : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Configuration du flip")]
    public bool flipX = true; // Flip sur l'axe X ?
    public bool flipY = false; // Flip sur l'axe Y ?

    void Start()
    {
        // R�cup�rer le SpriteRenderer attach� � ce GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Aucun SpriteRenderer trouv� sur ce GameObject.");
        }
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        // Obtenir la position de la souris en coordonn�es du monde
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculer la direction entre la souris et le GameObject
        Vector3 direction = mousePosition - transform.position;

        // Appliquer le flip selon les axes activ�s
        if (flipX)
        {
            spriteRenderer.flipX = direction.x < 0;
        }

        if (flipY)
        {
            spriteRenderer.flipY = direction.x < 0;
        }
    }
}