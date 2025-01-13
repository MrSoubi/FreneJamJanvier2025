using TMPro;
using UnityEngine;

public class DamageMarkerBehavior : MonoBehaviour
{
    [Header("Marker Settings")]
    [Tooltip("Vitesse du d�placement vers le haut.")]
    public float moveSpeed = 2f;

    [Tooltip("Dur�e avant la disparition du marker.")]
    public float lifetime = 1f;

    private float elapsedTime = 0f;

    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        // D�place le marker vers le haut
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Compte le temps �coul�
        elapsedTime += Time.deltaTime;

        // D�truit le marker apr�s la dur�e d�finie
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