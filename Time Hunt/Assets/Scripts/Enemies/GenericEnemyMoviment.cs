using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyMoviment : EnemyStates
{
    private Rigidbody2D rb; 
    private Animator animator;

    [SerializeField] private float speed = 3;
    [SerializeField] private float patrolDistance = 5f;

    [SerializeField] private Hitbox hitbox;
    private GameObject player;
    private bool playerInRange;

    private bool movingRight = true;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnEnter()
    {
        animator.SetBool("Walk", true);
    }

    public override void OnExit()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("Walk", false);
    }

    public override Type OnUpdate()
    {
        if(hitbox.IsTargetInHitbox())
        {
            playerInRange = true;
            return typeof(GenericEnemyAttack);
        }

        if (playerInRange)
        {
            Follow();
        }
        else 
        {
            Patrol();
        }     

        return null;
    }

    private void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (transform.position.x >= initialPosition.x + patrolDistance)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            if (transform.position.x <= initialPosition.x - patrolDistance)
            {
                Flip();
            }
        }
    }

    private void Follow()
    {
        Vector2 direction = player.transform.position - transform.position;

        rb.velocity = new Vector2(direction.normalized.x * speed, rb.velocity.y);

        if (direction.x > 0 && !movingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && movingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;

        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void SetFollow()
    {
        playerInRange = true;
    }

}
