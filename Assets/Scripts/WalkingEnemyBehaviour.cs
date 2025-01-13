using UnityEngine;

public class WalkingEnemyBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    public float groundMoveSpeed = 2f; // Speed at which the enemy moves towards the player on the ground
    public float airMoveSpeed = 1f; // Speed at which the enemy moves towards the player in the air
    public float damping = 0.1f; // Smoothing factor for movement

    [SerializeField] private PlayerDetector m_PlayerDetector;
    [SerializeField] private LayerMask groundLayer; // Layer mask to detect the ground

    private Transform playerTransform; // Reference to the player's transform
    private bool isPlayerDetected = false; // Tracks if the player is detected
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded = false; // Tracks if the enemy is on the ground

    [SerializeField] int damage = 1;
    private float pushForce = 1000;
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
        CheckIfGrounded();

        // If the player is detected, move towards the player with different speeds depending on grounded state
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

    private void CheckIfGrounded()
    {
        // Check for ground using a raycast
        float rayLength = 0.1f; // Length of the raycast
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);

        isGrounded = hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth;

        if (collision.gameObject.TryGetComponent<PlayerHealth>(out playerHealth))
        {
            playerHealth.TakeDamage(damage);
            Vector2 pushDirection =  (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce);
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = new Vector2(playerTransform.position.x - transform.position.x, 0).normalized;

        // Select movement speed based on whether the enemy is grounded
        float currentMoveSpeed = isGrounded ? groundMoveSpeed : airMoveSpeed;

        // Apply a smoothed force to move the enemy towards the player
        Vector2 targetVelocity = direction * currentMoveSpeed;
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
