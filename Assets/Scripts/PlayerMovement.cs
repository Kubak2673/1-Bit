using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5.5f;
    [SerializeField] private float jumpHeight = 9.5f;
    
    [Header("Components")]
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private BoxCollider2D boxCollider;

    private Rigidbody2D rb;
    
    // Holds horizontal input value (-1 to 1)
    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // In case the BoxCollider2D wasn’t assigned in the Inspector.
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }

    [System.Obsolete]
    void Update()
    {
        // Get horizontal movement input using the legacy input system.
        horizontal = Input.GetAxis("Horizontal");
        
        // Handle walking and stopping sliding.
        Walk();

        // Flip the sprite based on movement direction.
        FlipSprite();

        // Handle jump input.
        HandleJump();
    }

    [System.Obsolete]
    void HandleJump()
    {
        // Check if the Jump button is pressed.
        if (Input.GetButtonDown("Jump"))
        {
            // Only allow jump if the player is on the ground.
            if (boxCollider != null && !boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            Jump();
        }
    }

    [System.Obsolete]
    void Jump()
    {
        CreateDust();
        // Set the Y velocity for the jump while keeping the current X velocity.
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    [System.Obsolete]
    void Walk()
    {
        // If there is little to no horizontal input, stop horizontal movement to prevent sliding.
        if (Mathf.Abs(horizontal) < 0.01f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            // Set velocity based on input. (No need for Time.deltaTime because velocity is per second.)
            rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
        }
    }

    [System.Obsolete]
    void FlipSprite()
    {
        // Only flip sprite if there is significant horizontal movement.
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void CreateDust()
    {
        if (dust != null)
        {
            dust.Play();
        }
    }
}
