using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script responsavel por gerenciar os estados dos inimigos
/// </summary>
public class StatesManager : MonoBehaviour
{
    protected EnemyStates currentState;
    [SerializeField] protected List<EnemyStates> statesAvailable;

    private void Update()
    {
        var stateType = currentState?.OnUpdate();
        ChangeState(stateType);       
    }

    public void ChangeState(Type state)
    {
        if (state != null && state != currentState?.GetType())
        {
            var newState = statesAvailable.Find(e => e.GetType() == state);

            if (newState != null)
            {
                currentState?.OnExit();
                currentState = newState;
                currentState.OnEnter();
            }
        }
    }
}
