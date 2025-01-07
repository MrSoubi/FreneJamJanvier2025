using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
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

            if (m_JumpInput)
            {
                m_JumpInput = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
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
                }
                if (IsTouchingRightWall())
                {
                    m_JumpInput = false;
                    jumpForce = RotateVector2(Vector2.up, m_WallJumpAngle) * m_WallJumpForce;
                }

                m_Rigidbody2D.AddForce(jumpForce);
            }

        }

        targetVelocity = new Vector2(m_MoveInput * speed, m_Rigidbody2D.linearVelocity.y);
        m_Rigidbody2D.linearVelocity = Vector3.SmoothDamp(m_Rigidbody2D.linearVelocity, targetVelocity, ref m_Velocity, movementSmoothing);
        m_Rigidbody2D.linearVelocity = Vector2.ClampMagnitude(m_Rigidbody2D.linearVelocity, maxSpeed);
    }

    #region SurfaceCheck
    private bool IsGrounded()
    {
        return IsTouchingSurface(m_GroundCheck.position);
    }

    private bool IsTouchingRightWall()
    {
        return IsTouchingSurface(m_WallCheckRight.position);
    }

    private bool IsTouchingLeftWall()
    {
        Debug.Log("check left wall");
        return IsTouchingSurface(m_WallCheckLeft.position);
    }

    private bool IsTouchingSurface(Vector3 position)
    {
        bool result = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, k_GroundedRadius, m_WhatIsGround);
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
