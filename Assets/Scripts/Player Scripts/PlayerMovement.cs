using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public void Move(Vector2 direction);
    public void Jump();
}

public class PlayerMovement : MonoBehaviour, IMoveable
{
    private PlayerStats _playerStats;
    private Rigidbody2D rb;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * _playerStats.GetMovementSpeed() * Time.deltaTime , rb.velocity.y);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * _playerStats.GetJumpForce() * Time.deltaTime, ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckRadius, groundLayer);
        if (hit)
            return true;
        else
            return false;
    }

    public Vector2 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        return new Vector2(horizontal, 0);
    }

    // Gizmos for Ground Check
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * groundCheckRadius);
    }

}
