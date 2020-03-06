using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float horizontal;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int jump;
    public int setJumps;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            jump = setJumps;
        }

        if ((Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.Space))) && jump > 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            jump--;
        }
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (facingRight == false && horizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && horizontal < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}