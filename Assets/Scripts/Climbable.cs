using UnityEngine;

public class Climbable : MonoBehaviour
{
    public bool isClimbable = false;
    PlayerClimber playerClimber;

    private void Awake()
    {
        playerClimber = FindObjectOfType<PlayerClimber>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbable = true;
            if (playerClimber != null)
            {
                playerClimber.SetClimbable(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbable = false;
            if (playerClimber != null)
            {
                playerClimber.SetClimbable(false);
            }
        }
        playerClimber.rb.gravityScale = 1;
    }
}
