using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public float rollBoost = 2f;
    private float rollTime;
    public float RollTime;
    bool rollOnce = false;

    public SpriteRenderer characterSR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        UpdateAnimation();
        FlipCharacter();
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("Roll", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
        }
        if (rollTime <= 0 && rollOnce == true)
        {
            animator.SetBool("Roll", false);
            moveSpeed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        } 
        
    }

    private void MovePlayer()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.deltaTime));
    }


    private void UpdateAnimation()
    {
        bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f;
        animator.SetBool("Movement", isMoving);
    }

    private void FlipCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            characterSR.transform.localScale = new Vector3(1f, 1f, 1); // Quay sang phải
        }
        else if (horizontalInput < 0)
        {
            characterSR.transform.localScale = new Vector3(-1f, 1f, 1); // Quay sang trái
        }
    }
}