using UnityEngine;

public class PlayerClimber : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isClimbable = false;
    [SerializeField] private float climbingSpeed = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Climb();
    }

    public void Climb()
    {
        if (isClimbable)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                transform.Translate(Vector3.up * Time.deltaTime * climbingSpeed);
            }
            else if(Input.GetKeyUp(KeyCode.W))
                {
                rb.gravityScale = 0;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
            {
                rb.gravityScale = 0;
                transform.Translate(Vector3.down * Time.deltaTime * climbingSpeed);
            }
        }
    }

    public void SetClimbable(bool canClimb)
    {
        isClimbable = canClimb;
    }
}
