using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public RSO_ProjectileCount projectileCount;

    [Header("Shoot Settings")]
    [Tooltip("Position o� le projectile sera instanci�.")]
    public Transform shootPoint;

    [Tooltip("Prefab du projectile � instancier.")]
    public GameObject projectilePrefab;

    [Tooltip("Vitesse de lancement du projectile.")]
    public float projectileSpeed = 10f;

    void Update()
    {
        // V�rifie si le clic gauche de la souris est press�
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            // Instancie le projectile au point de tir
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            // Ajoute une force au projectile si un Rigidbody2D est pr�sent
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = shootPoint.right * projectileSpeed; // Assume que le point de tir regarde dans la bonne direction
            }

            projectileCount.Value++;
        }
        else
        {
            Debug.LogWarning("ShootPoint ou ProjectilePrefab n'est pas assign� dans l'inspecteur.");
        }
    }
}
