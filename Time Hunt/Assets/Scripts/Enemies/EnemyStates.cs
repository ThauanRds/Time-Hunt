using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Script responsavel por criar os estados dos inimigos
/// </summary>
public abstract class EnemyStates : MonoBehaviour
{
    public abstract void OnEnter();

    public abstract Type OnUpdate();

    public abstract void OnExit();
}
