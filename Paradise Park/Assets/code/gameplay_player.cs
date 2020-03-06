using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT ACTS AS THE MOVEMENT CONTROLS FOR THE PLAYER

public class gameplay_player : MonoBehaviour {
    /*FindGameObjectWithTag IS KEY*/

    public Animator anim;
    public float speed;
    private float moveInput;

    private Rigidbody2D rb;
    public float jumpForce;
    private float jumpTimeCounter;
       //all of these check if the player is on the ground and therefore able to jump
    private bool isGroundedLeft;
    private bool isGroundedRight;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask whatIsGround;
    public float checkRadius;
    

    public static int dirFaced;
    public static GameObject player;

    void Start()
    {
        player = this.gameObject;
           //assigning player rb
        rb = GetComponent<Rigidbody2D>();
        dirFaced = 1;
    }


    void FixedUpdate()
    {
        //Debug.Log(dirFaced);
           //jump check
        isGroundedLeft = Physics2D.OverlapCircle(groundCheckLeft.position, checkRadius, whatIsGround);
        isGroundedRight = Physics2D.OverlapCircle(groundCheckRight.position, checkRadius, whatIsGround);

           //these two lines allow for movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //allows the player to jump
        if (Input.GetKeyDown(KeyCode.W) && (isGroundedLeft == true || isGroundedRight == true))
        {
            //rb.velocity = Vector2.up * jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        //ground pound
        if (Input.GetKeyDown(KeyCode.S) && !(isGroundedLeft == true || isGroundedRight == true))
        {
            rb.velocity = Vector2.down * jumpForce * 5;
        }
        /*
        if (moveInput < 0)
        {
            dirFaced = -1;
            flip();
        }
        else if(moveInput > 0)
        {
            dirFaced = 1;
            flip();
        }       */
    }

    public static void flip()
    {
        if(dirFaced == -1)
        {
            player.transform.eulerAngles = new Vector3(0, 180, 0); 
        }            
        if(dirFaced == 1)
        {
            player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
            
    }
}
