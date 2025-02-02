using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Output Data")]
    public RSO_TotalWalkDistance totalWalkDistance;

    [Header("Output Events")]
    public RSE_PlayerJump playerJump;
    public RSE_PlayerMoveLeft playerMoveLeft;
    public RSE_PlayerMoveRight playerMoveRight;
    public RSE_PlayerWallJump playerWallJump;

    public RSO_JumpCount jumpCount;
    public RSO_WallJumpCount wallJumpCount;

    [SerializeField] private float m_JumpForce = 400f;
    [SerializeField] private float m_WallJumpForce = 1000f;
    [SerializeField] private float m_GroundSpeed = 10f;
    [SerializeField] private float m_AirSpeed = 10f;
    [SerializeField] private float m_MaxGroundSpeed = 10f;
    [SerializeField] private float m_MaxAirSpeed = 10f;
    [Range(0, .3f)][SerializeField] private float m_GroundMovementSmoothing = .05f;
    [Range(0, .3f)][SerializeField] private float m_AirMovementSmoothing = .05f;

    [SerializeField] private float m_WallJumpAngle = 30f;

    [SerializeField] private LayerMask m_WhatIsGround; // Oh, Baby don't hurt me...

    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_WallCheckRight;
    [SerializeField] private Transform m_WallCheckLeft;

    [SerializeField] private Rigidbody2D m_Rigidbody2D;

    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    const float k_GroundedRadius = .05f;
    const float k_WallCheckRadius = .05f;
    private bool m_IsGrounded;
    private bool m_IsFacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    private float m_MoveInput = 0f;
    private bool m_JumpInput = false;
    private bool m_IsJumping = false;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        m_MoveInput = Input.GetAxis("Horizontal");
        m_JumpInput |= Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        m_IsGrounded = IsGrounded();

        float speed;
        float maxSpeed;
        float movementSmoothing;
        Vector3 targetVelocity;

        if (m_IsGrounded)
        {
            speed = m_GroundSpeed;
            maxSpeed = m_MaxGroundSpeed;
            movementSmoothing = m_GroundMovementSmoothing;

            Vector2 walkedDistance = transform.position - lastPosition;
            totalWalkDistance.Value += walkedDistance.magnitude;
            lastPosition = transform.position;

            if (m_JumpInput)
            {
                m_JumpInput = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                jumpCount.Value++;
                playerJump.FireEvent();
            }
        }
        else
        {
            speed = m_AirSpeed;
            maxSpeed = m_MaxAirSpeed;
            movementSmoothing = m_AirMovementSmoothing;

            if (m_JumpInput && Mathf.Abs(m_MoveInput) > 0)
            {
                Vector2 jumpForce = Vector2.zero;

                if (IsTouchingLeftWall())
                {
                    m_JumpInput = false;
                    jumpForce = RotateVector2(Vector2.up, -m_WallJumpAngle) * m_WallJumpForce;
                    wallJumpCount.Value++;
                    playerWallJump?.FireEvent();
                }
                if (IsTouchingRightWall())
                {
                    m_JumpInput = false;
                    jumpForce = RotateVector2(Vector2.up, m_WallJumpAngle) * m_WallJumpForce;
                    wallJumpCount.Value++;
                    playerWallJump?.FireEvent();
                }

                m_Rigidbody2D.AddForce(jumpForce);
            }

        }

        if (m_MoveInput > 0)
        {
            playerMoveRight?.FireEvent();
        }
        if (m_MoveInput < 0)
        {
            playerMoveLeft?.FireEvent();
        }

        targetVelocity = new Vector2(m_MoveInput * speed, m_Rigidbody2D.linearVelocity.y);
        m_Rigidbody2D.linearVelocity = Vector3.SmoothDamp(m_Rigidbody2D.linearVelocity, targetVelocity, ref m_Velocity, movementSmoothing);
        m_Rigidbody2D.linearVelocity = Vector2.ClampMagnitude(m_Rigidbody2D.linearVelocity, maxSpeed);

        m_JumpInput = false;
    }

    #region SurfaceCheck
    private bool IsGrounded()
    {
        return IsTouchingSurface(m_GroundCheck.position, 0.1f, 0.5f);
    }

    private bool IsTouchingRightWall()
    {
        return IsTouchingSurface(m_WallCheckRight.position, 1, 0.1f);
    }

    private bool IsTouchingLeftWall()
    {
        Debug.Log("check left wall");
        return IsTouchingSurface(m_WallCheckLeft.position, 1, 0.1f);
    }

    private bool IsTouchingSurface(Vector3 position, float height, float width)
    {
        bool result = false;

        Vector3 position_A = new Vector3(position.x - height, position.y - width, position.z);
        Vector3 position_B = new Vector3(position.x + height, position.y + width, position.z);

        Collider2D[] colliders = Physics2D.OverlapAreaAll(position_A, position_B, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                result = true;
            }
        }

        return result;
    }
    #endregion

    public Vector2 RotateVector2(Vector2 originalVector, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;

        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        float newX = originalVector.x * cos - originalVector.y * sin;
        float newY = originalVector.x * sin + originalVector.y * cos;

        return new Vector2(newX, newY);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(m_GroundCheck.position, k_GroundedRadius);
        Gizmos.DrawSphere(m_WallCheckRight.position, k_GroundedRadius);
        Gizmos.DrawSphere(m_WallCheckLeft.position, k_GroundedRadius);
    }
}
