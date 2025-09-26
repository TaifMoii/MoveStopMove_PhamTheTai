using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EIdleState : EIState
{
    float timeDelay;
    public void OnEnter(EnemyController enemy)
    {
        enemy.Idle();
        enemy.WaitIdles();
        timeDelay = 0f;
    }

    public void OnExecute(EnemyController enemy)
    {
        timeDelay += Time.deltaTime;
        enemy.FindTarget();

        if (enemy.Target != null && !enemy.isMoving)
        {
            enemy.ChangeState(new EAttackState());
        }
        if (timeDelay >= 2f)
        {
            if (enemy.Target == null && !enemy.isMoving)
            {
                enemy.ChangeState(new ERunState());
            }

            timeDelay = 0;
        }


    }

    public void OnExit(EnemyController enemy)
    {
    }

}
