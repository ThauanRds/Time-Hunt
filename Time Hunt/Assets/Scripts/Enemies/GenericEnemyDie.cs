using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyDie : EnemyStates
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 3f);
    }

    public override void OnExit()
    {
        
    }

    public override Type OnUpdate()
    {
        return null;
    }


}
