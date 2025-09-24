using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EIdleState : EIState
{
    public void OnEnter(EnemyController enemy)
    {
        enemy.isMoving = false;
        enemy.Idle();
        enemy.WaitIdles();

    }

    public void OnExecute(EnemyController enemy)
    {
        enemy.FindTarget();
        if (enemy.Target == null && !enemy.isMoving)
        {
            enemy.ChangeState(new ERunState());
        }
        if (enemy.Target != null && !enemy.isMoving)
        {
            enemy.ChangeState(new EAttackState());
        }

    }

    public void OnExit(EnemyController enemy)
    {
    }

}
