using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public RSO_ProjectileCount projectileCount;
    public RSE_PlayerShoot playerShoot;

    [Header("Shoot Settings")]
    [Tooltip("Position où le projectile sera instancié.")]
    public Transform shootPoint;

    [Tooltip("Prefab du projectile à instancier.")]
    public GameObject projectilePrefab;

    [Tooltip("Vitesse de lancement du projectile.")]
    public float projectileSpeed = 10f;

    [Tooltip("Temps de cooldown entre deux tirs (en secondes).")]
    public float shootCooldown = 0.5f;

    private float lastShootTime;

    void Update()
    {
        // Vérifie si le clic gauche de la souris est pressé et que le cooldown est terminé
        if (Input.GetMouseButton(0) && Time.time >= lastShootTime + shootCooldown)
        {
            ShootProjectile();
            lastShootTime = Time.time; // Met à jour le temps du dernier tir
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            // Instancie le projectile au point de tir
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            // Ajoute une force au projectile si un Rigidbody2D est présent
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = shootPoint.right * projectileSpeed; // Assume que le point de tir regarde dans la bonne direction
            }

            playerShoot?.FireEvent();
            projectileCount.Value++;
        }
        else
        {
            Debug.LogWarning("ShootPoint ou ProjectilePrefab n'est pas assigné dans l'inspecteur.");
        }
    }
}
