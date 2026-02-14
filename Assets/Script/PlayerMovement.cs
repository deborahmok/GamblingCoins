using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Animation")]
    [SerializeField] private Sprite walkA;
    [SerializeField] private Sprite walkB;
    [SerializeField] private float animationSpeed = 0.2f;

    private SpriteRenderer sr;
    private float animationTimer;
    private bool toggle;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
    }
    
    private void Animate()
    {
        if (movement.magnitude > 0.1f)
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
            sr.sprite = walkA;
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = movement * moveSpeed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 0.2f);
    }
}