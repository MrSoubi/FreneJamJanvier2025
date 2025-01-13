using TMPro;
using UnityEngine;

public class DamageMarkerBehavior : MonoBehaviour
{
    [Header("Marker Settings")]
    [Tooltip("Vitesse du déplacement vers le haut.")]
    public float moveSpeed = 2f;

    [Tooltip("Durée avant la disparition du marker.")]
    public float lifetime = 1f;

    private float elapsedTime = 0f;

    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        // Déplace le marker vers le haut
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Compte le temps écoulé
        elapsedTime += Time.deltaTime;

        // Détruit le marker après la durée définie
        if (elapsedTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void SetValue(int value)
    {
        text.text = value.ToString();
    }
}