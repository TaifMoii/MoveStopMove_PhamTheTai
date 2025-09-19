using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERunState : EIState
{
    public void OnEnter(EnemyController enemy)
    {
        enemy.Run();
    }

    public void OnExecute(EnemyController enemy)
    {

    }

    public void OnExit(EnemyController enemy)
    {
    }
}
