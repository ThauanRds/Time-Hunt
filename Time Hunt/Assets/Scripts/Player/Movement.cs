using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    private float inputHorizontal;
    [SerializeField] private float speed;

    [Header("Jump Settings: ")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private bool extraJump;

    private DirectionPlayer directionPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if(inputHorizontal > 0)
        {
            FlipPlayer(DirectionPlayer.Right);
        }
        else if(inputHorizontal < 0)
        {
            FlipPlayer(DirectionPlayer.Left);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 300f);
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
}

enum DirectionPlayer 
{
    Left,
    Right
}
