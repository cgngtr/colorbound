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
    public float bounceSpeed = 50f; // Bounce hızı
    public float slowTimeDistance = 5f; // Yavaşlatmanın başlayacağı mesafe
    public float distanceToPad;
    private bool isTimeSlowed = false;

    private Transform playerTransform; // Oyuncunun pozisyonunu almak için

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0; // Drag sıfır
        _ctm = GetComponent<CircleTimingMechanic>();
        _colorState = GetComponent<ColorState>();
        _playerStats = GetComponent<PlayerStats>();
        _playerMovement = GetComponent<PlayerMovement>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncuyu bul
    }

    private void FixedUpdate()
    {
        // Mesafe kontrolü
        distanceToPad = Vector2.Distance(playerTransform.position, transform.position);

        // Eğer oyuncu belirlenen mesafeden yakınsa zaman yavaşlasın
        if (distanceToPad <= slowTimeDistance && !isTimeSlowed)
        {
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.SlowTimeSpeed(); // Zamanı yavaşlat
            isTimeSlowed = true; // Tekrar yavaşlatmayı engellemek için bayrak
        }
        // Eğer oyuncu pad'e çok yakın değilse ve zaman yavaşlatılmışsa, zamanı normale döndür
        else if (distanceToPad > slowTimeDistance && isTimeSlowed)
        {
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.ResetTimeSpeed(); // Zamanı normale döndür
            isTimeSlowed = false; // Zaman normale döndü
        }

        // Bounce zamanı kontrol
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            if (_ctm.isPerfectlyPressed) // Eğer X tuşuna mükemmel zamanda basıldıysa
            {
                isBouncing = true;
                bounceTimer = bounceDuration;
                LaunchPlayer(bounceSpeed);

                _ctm.isPerfectlyPressed = false; // Sıfırlama
                TimeManager timeManager = FindObjectOfType<TimeManager>();
                timeManager.ResetTimeSpeed(); // Zaman normale dönsün
                isTimeSlowed = false; // Zaman yavaşlatmayı sıfırla
            }
        }
    }

    public void LaunchPlayer(float speed)
    {
        _playerMovement.SetBouncing(true);
        float direction = -_playerStats.CheckDirection(); // Yön al
        rb.velocity = new Vector2(direction * speed, rb.velocity.y); // Hız ayarla
    }
}
