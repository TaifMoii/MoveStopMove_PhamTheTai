using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackState : EIState
{
    float timeDelay;
    public void OnEnter(EnemyController enemy)
    {
        enemy.Attack();
        timeDelay = 0;
    }

    public void OnExecute(EnemyController enemy)
    {
        timeDelay += Time.deltaTime;
        if (enemy.Target == null)
        {
            enemy.ChangeState(new EAttackState());
        }
        else
        {
            if (timeDelay >= 2.5f)
            {
                enemy.ChangeState(new EIdleState());
            }
            if (enemy.isMoving)
            {
                enemy.ChangeState(new ERunState());

            }
        }

    }

    public void OnExit(EnemyController enemy)
    {
        enemy.ResetTarget();
    }

}
