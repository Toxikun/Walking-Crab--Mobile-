using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float moveInput = 0f;
    private Vector3 originalScale;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Animasyonu güncelle
        animator.SetBool("isWalking", moveInput != 0);

        if (moveInput > 0)
            transform.localScale = originalScale;
        else if (moveInput < 0)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
    }

    public void MoveLeft(bool isPressed)
    {
        if (isPressed)
            moveInput = -1f;
        else if (moveInput < 0)
            moveInput = 0f;
    }

    public void MoveRight(bool isPressed)
    {
        if (isPressed)
            moveInput = 1f;
        else if (moveInput > 0)
            moveInput = 0f;
    }
}
