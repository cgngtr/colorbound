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
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    public bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * moveSpeed * Time.deltaTime , rb.velocity.y);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckRadius, groundLayer);
        if(hit)
        { 
           isGrounded = true;
           return true;
        }
        else
        {
            isGrounded = false;
            return false;
        }
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
