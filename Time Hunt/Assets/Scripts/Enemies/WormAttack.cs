using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAttack : EnemyStates
{
    [SerializeField] private Hitbox hitbox;
    private Animator anim;

    private Transform player;

    [SerializeField] private float delayAttack;
    private float timer;

    [SerializeField] private FireBall fireBallPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private int damage;
    [SerializeField] private int speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override Type OnUpdate()
    {
        FlipEnemy();

        if (hitbox.IsTargetInHitbox())
        {
            timer += Time.deltaTime;
            if (timer > delayAttack)
            {
                timer = 0;
                anim.SetTrigger("Attack");
            }
        }

        return null;
    }

    public void RealizeAttack()
    {
        FireBall fireBall = Instantiate(fireBallPrefab, spawnPoint.position, Quaternion.identity);
        fireBall.LaunchFireBall(player, speed, damage, true);
    }

    private void FlipEnemy()
    {
        if(player.transform.position.x < transform.position.x)
        { 
           transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
 
}
