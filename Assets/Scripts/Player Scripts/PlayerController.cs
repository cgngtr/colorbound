using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private bool jumpPressed = false;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
        _playerInput.ChangeColorState();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = _playerMovement.GetMovementInput();
        _playerMovement.Move(movementInput);

        if (_playerMovement.IsGrounded() && jumpPressed)
        {
            _playerMovement.Jump();
            jumpPressed = false;
        }
    }
}

