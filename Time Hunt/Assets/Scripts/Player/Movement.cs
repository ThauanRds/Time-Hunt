using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    private float inputHorizontal;
    [SerializeField] private float speed;

    [Header("Jump Settings: ")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool extraJump;

    private DirectionPlayer directionPlayer;

    private bool canUseDash = true;
    private bool usingDash = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        directionPlayer = DirectionPlayer.Right;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded)
        {
            extraJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                Jump();
            }
            else if(extraJump)
            {
                extraJump = false;
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && canUseDash)
        {
            StartCoroutine(Dash());
        }

        if(inputHorizontal > 0)
        {
            FlipPlayer(DirectionPlayer.Right);
        }
        else if(inputHorizontal < 0)
        {
            FlipPlayer(DirectionPlayer.Left);
        }

        anim.SetBool("Run", inputHorizontal != 0);
        anim.SetBool("IsOnGround", isGrounded);
    }

    void FixedUpdate()
    {
        if(!usingDash)     
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 300f);

        anim.SetTrigger("Jump");
    }

    private void FlipPlayer(DirectionPlayer direction)
    {
        if(direction == directionPlayer)
        {
            return;
        }

        directionPlayer = direction;

        if (directionPlayer == DirectionPlayer.Right)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private IEnumerator Dash()
    {
        canUseDash = false;
        usingDash = true;

        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;

        if (directionPlayer == DirectionPlayer.Right)
        {
            rb.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(0.3f);

        usingDash = false;
        rb.gravityScale = 1;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(3);
        canUseDash = true;
    }
}

enum DirectionPlayer 
{
    Left,
    Right
}
