using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyAttack : EnemyStates
{
    private Animator animator;

    [SerializeField] private int damage = 20;
    [SerializeField] private Hitbox hitbox;
    [SerializeField] private float attackCooldown;

    private Type nextStage = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        Invoke(nameof(Attack), attackCooldown);
    }

    public override void OnExit()
    {
        nextStage = null;
        CancelInvoke();
    }

    public override Type OnUpdate()
    {
        return nextStage;
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void RealizeAttack()
    {
        hitbox.ApplyDamage(damage);
        Invoke(nameof(FinishAttack), attackCooldown);
    }

    private void FinishAttack()
    {
        nextStage = typeof(GenericEnemyMoviment);
    }

}
