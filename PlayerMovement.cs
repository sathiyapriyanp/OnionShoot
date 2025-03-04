using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    [Header("Collision Check")]
    public float xInput;
    public float speed = 5;
    public float jumpForce = 50.0f;
    public float groundCheckRadius;
    public bool isGrounded;
    public bool faceRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        AnimationController();
        CollisionChecks();
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerJump();
        FlipControl();
    }

    private void FlipControl()
    {
        if (rb.velocity.x < 0 && faceRight)
            Flip();
        else if (rb.velocity.x > 0 && !faceRight)
            Flip();
    }

    private void AnimationController()
    {
        /*isMoving = rb.velocity.x != 0;
        Debug.Log("ismove");*/
        anim.SetFloat("xVelocity", rb.velocity.x);

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void PlayerJump()
    {
        if (isGrounded)
        {

            Debug.Log("key press");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log(rb.velocity);
        }
    }

    private void PlayerMove()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

}
