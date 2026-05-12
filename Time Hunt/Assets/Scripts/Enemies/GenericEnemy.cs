using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : StatesManager
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(typeof(GenericEnemyMoviment));
    }
    
    public void TakeHit()
    {
        ChangeState(typeof(GenericEnemyTakeHit));
    }

    public void Die()
    {
        ChangeState(typeof(GenericEnemyDie));
    }
}
