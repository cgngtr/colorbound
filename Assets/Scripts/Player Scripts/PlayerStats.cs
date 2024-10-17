using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private ColorState _colorState;
    private Rigidbody2D rb;

    public float BaseMovementSpeed { get; private set; } = 250f;
    public float BaseJumpForce { get; private set; } = 250f;
    public float BaseAttackDamage { get; private set; } = 2f;


    [Header("Current Stats")]
    [SerializeField] private float currentMovementSpeed;
    [SerializeField] private float currentJumpForce;
    [SerializeField] private float currentAttackDamage;
    [SerializeField] private Vector2 velocity; // Temporarily added.


    private void Awake()
    {
        _colorState = GetComponent<ColorState>();
        rb = GetComponent<Rigidbody2D>();
    }
        
    private void Start()
    {
        currentMovementSpeed = BaseMovementSpeed;
        currentJumpForce = BaseJumpForce;
        currentAttackDamage = BaseAttackDamage;
    }

    private void Update()
    {
        _colorState.GetCurrentState();
        velocity = new Vector2(rb.velocity.x,rb.velocity.y);
    }

    public int CheckDirection()
    {
        if ((rb.velocity.x > 0))
        {
            return 1;
        }
        else if(rb.velocity.x < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    #region Controlling Movement Speed
    public void SetMovementSpeed(float speed)
    {
        currentMovementSpeed = speed;
    }

    public void ResetMovementSpeed()
    {
        currentMovementSpeed = BaseMovementSpeed;
    }

    public float GetMovementSpeed()
    {
        return currentMovementSpeed;
    }
    #endregion


    #region Controlling Jump Force
    public void SetJumpForce(float force)
    {
        currentJumpForce = force;
    }
    public void ResetJumpForce()
    {
        currentJumpForce = BaseJumpForce;
    }
    public float GetJumpForce()
    {
        return currentJumpForce;
    }
    #endregion


    #region Controlling Attack Damage
    public void SetAttackDamage(float damage)
    {
        currentAttackDamage = damage;
    }
    
    public void ResetAttackDamage()
    {
        currentAttackDamage = BaseAttackDamage;
    }

    public float GetAttackDamage()
    {
        return currentAttackDamage;
    }
    #endregion
}
