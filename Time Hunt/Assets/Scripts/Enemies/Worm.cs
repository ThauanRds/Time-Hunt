using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : StatesManager
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(typeof(WormAttack));
    }

    public void Die()
    {
        ChangeState(typeof(GenericEnemyDie));
    }

    
}
