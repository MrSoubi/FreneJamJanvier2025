using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float groundDetectionDistance = 1f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float xMovement = 0f;

        xMovement = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(xMovement, rb.linearVelocity.y);

        if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundDetectionDistance, groundMask);
    }
}
