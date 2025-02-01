using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    private Rigidbody2D rb; 
    private BoxCollider2D boxCollider;
    Vector2 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Walk();
        FlipSprite();
    }
    void OnJump(InputValue value)
    {
        if(rb != null)
        {
            if(boxCollider != null)
            {
                if (!boxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    return;
                }
            }
            if (value.isPressed)
            {
                rb.linearVelocity += new Vector2(0, jumpHeight);
            }
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * walkSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
    }
    void FlipSprite() 
    {
        bool playerHasSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
        transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }
}
