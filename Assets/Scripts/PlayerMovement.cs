using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ustawienia ruchu")]
    [SerializeField] private float walkSpeed = 5.5f;
    [SerializeField] private float jumpHeight = 9.5f;
    [SerializeField] private float deceleration = 10f;

    [Header("Komponenty")]
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] AudioClip impact;
    AudioSource audioSource;
    private Rigidbody2D rb;
    private float horizontal;
    private bool inAir = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }

    void OnEnable()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        inAir = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Walk();
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
        audioSource.PlayOneShot(impact, 1f);
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

    void CreateDust()
    {
        if (dust != null)
        {
            dust.Play();
        }
    }
}
