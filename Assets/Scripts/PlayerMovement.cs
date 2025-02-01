using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ustawienia ruchu")]
    [SerializeField] private float walkSpeed = 5.5f;
    [SerializeField] private float jumpHeight = 9.5f;
    [SerializeField] private float deceleration = 10f;

    [Header("Komponenty")]
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private BoxCollider2D boxCollider;

    private Rigidbody2D rb;
    private float horizontal;
    private bool inAir = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Walk();
        FlipSprite();
        HandleJump();
        if (inAir && boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            inAir = false;
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (boxCollider != null && !boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                return;
            Jump();
        }
    }

    void Jump()
    {
        CreateDust();
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
        inAir = true;
    }

    void Walk()
    {
        if (Mathf.Abs(horizontal) < 0.01f)
        {
            rb.linearVelocity = new Vector2(Mathf.Lerp(rb.linearVelocity.x, 0, deceleration * Time.deltaTime), rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(horizontal * walkSpeed, rb.linearVelocity.y);
        }
    }

    void FlipSprite()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
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
