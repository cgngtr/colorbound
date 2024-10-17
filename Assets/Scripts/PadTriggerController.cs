using UnityEngine;

public class PadTriggerController : MonoBehaviour
{
    private CircleTimingMechanic _ctm;
    private ColorState _colorState;
    private PlayerStats _playerStats;
    private Rigidbody2D rb;
    private PlayerMovement _playerMovement;

    public bool isBouncing = false;
    public float bounceTimer = 0f;
    public float bounceDuration = 0.2f;
    public float bounceSpeed = 50f; // Added a public field for bounce speed

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0; // Ensure drag is set to zero
        _ctm = GetComponent<CircleTimingMechanic>();
        _colorState = GetComponent<ColorState>();
        _playerStats = GetComponent<PlayerStats>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            isBouncing = true;
            bounceTimer = bounceDuration;
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.SlowTimeSpeed();

            if (Vector3.Distance(transform.position, collision.transform.position) < 2f && _ctm.isPerfect && _colorState.GetCurrentState() == ColorState.Red)
            {
                timeManager.ResetTimeSpeed();
                LaunchPlayer(bounceSpeed);
            }
            else
            {
                timeManager.ResetTimeSpeed();
            }
        }
    }

    private void Update()
    {
        if (isBouncing)
        {
            bounceTimer -= Time.deltaTime;
            if (bounceTimer <= 0)
            {
                isBouncing = false;
                _playerMovement.SetBouncing(false);
            }
        }
    }

    public void LaunchPlayer(float speed)
    {
        _playerMovement.SetBouncing(true);
        float direction = -_playerStats.CheckDirection(); // Get the direction to apply force
        rb.velocity = new Vector2(direction * speed, rb.velocity.y); // Set velocity directly for consistent bounce
    }
}
