using UnityEngine;

public class DamageMarker : MonoBehaviour
{
    public Health healthComponent;

    [SerializeField] GameObject hitMarkerPrefab;

    void Start()
    {
        if (healthComponent != null)
        {
            healthComponent.onTakeDamage.AddListener(HandleDamageTaken);
        }
    }

    void HandleDamageTaken(int damage)
    {
        Instantiate(hitMarkerPrefab, transform.position, Quaternion.identity);
    }
}