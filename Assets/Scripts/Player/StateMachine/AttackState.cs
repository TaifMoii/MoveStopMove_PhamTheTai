using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    float timeDelay;
    public void OnEnter(PlayerController player)
    {
        player.Attack();
        timeDelay = 0;
    }

    public void OnExecute(PlayerController player)
    {
        timeDelay += Time.deltaTime;
        if (player.Target == null)
        {
            player.ChangeState(new IdleSate());
        }
        else
        {
            if (timeDelay >= 2.5f)
            {
                player.ChangeState(new IdleSate());
            }
            if (player.isMoving)
            {
                player.ChangeState(new RunState());

            }
        }

    }

    public void OnExit(PlayerController player)
    {
        player.ResetTarget();
    }

}
