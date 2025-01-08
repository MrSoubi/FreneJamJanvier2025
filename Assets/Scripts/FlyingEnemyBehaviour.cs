using UnityEngine;

public class FlyingEnemyBehaviour : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the player
    public float damping = 0.1f; // Smoothing factor for movement

    [SerializeField] private PlayerDetector m_PlayerDetector;

    private Transform playerTransform; // Reference to the player's transform
    private bool isPlayerDetected = false; // Tracks if the player is detected
    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        m_PlayerDetector.OnPlayerEnter.AddListener(OnPlayerDetected);
        m_PlayerDetector.OnPlayerExit.AddListener(OnPlayerLost);
    }

    private void FixedUpdate()
    {
        // If the player is detected, move towards the player with damping
        if (isPlayerDetected && playerTransform != null)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // Gradually reduce velocity to zero when the player is lost
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, damping);
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        // Apply a smoothed force to move the enemy towards the player
        Vector2 targetVelocity = direction * moveSpeed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, damping);
    }

    public void OnPlayerDetected(Transform player)
    {
        // Set the player as the detected target
        playerTransform = player;
        isPlayerDetected = true;
    }

    public void OnPlayerLost()
    {
        // Reset detection when the player is no longer in range
        isPlayerDetected = false;
        playerTransform = null;
    }
}
