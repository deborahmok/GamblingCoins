using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Animation")]
    [SerializeField] private Sprite walkA;
    [SerializeField] private Sprite walkB;
    [SerializeField] private float animationSpeed = 0.2f;
    
    [Header("Audio")]
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private float stepInterval = 0.35f; // tweak to match your clip

    private float stepTimer;
    private AudioSource audioSource;

    private SpriteRenderer sr;
    private float animationTimer;
    private bool toggle;

    private Rigidbody2D rb;
    private Vector2 movement;
    
    private bool wasMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (movement.x != 0)
        {
            sr.flipX = movement.x < 0;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        Animate();
        HandleWalkingSound();
    }
    
    private void Animate()
    {
        if (walkA == null || walkB == null) return;

        bool isMoving = movement.magnitude > 0.1f;

        // If movement JUST started, instantly show the other frame
        if (isMoving && !wasMoving)
        {
            toggle = !toggle;
            sr.sprite = toggle ? walkA : walkB;
            animationTimer = 0f;
        }

        if (isMoving)
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= animationSpeed)
            {
                toggle = !toggle;
                sr.sprite = toggle ? walkA : walkB;
                animationTimer = 0f;
            }
        }
        else
        {
            sr.sprite = walkA;     // idle
            animationTimer = 0f;   // reset so next move starts snappy
        }

        wasMoving = isMoving;
    }

    private void HandleWalkingSound()
    {
        if (walkSound == null || audioSource == null) return;

        bool isMoving = movement.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                audioSource.PlayOneShot(walkSound);
                stepTimer = stepInterval;
            }
        }
        else
        {
            // don’t cut sound; just reset timer so next move plays immediately
            stepTimer = 0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = movement * moveSpeed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 0.2f);
    }
}