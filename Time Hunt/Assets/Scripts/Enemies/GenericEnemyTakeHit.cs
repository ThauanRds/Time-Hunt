using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyTakeHit : EnemyStates
{
    private Animator animator;
    [SerializeField] private float hitDuration;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Hit");
    }

    public override void OnExit()
    {
        timer = 0;
    }

    public override Type OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > hitDuration)
        {
            return typeof(GenericEnemyMoviment);
        }
        return null;
    }
   
}
