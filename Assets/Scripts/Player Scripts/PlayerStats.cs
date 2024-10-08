using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private ColorState _colorState;

    public float BaseMovementSpeed { get; private set; } = 250f;
    public float BaseJumpForce { get; private set; } = 250f;
    public float BaseAttackDamage { get; private set; } = 2f;

    [Header("Current Stats")]
    [SerializeField] private float currentMovementSpeed;
    [SerializeField] private float currentJumpForce;
    [SerializeField] private float currentAttackDamage;


    private void Awake()
    {
        _colorState = GetComponent<ColorState>();
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
