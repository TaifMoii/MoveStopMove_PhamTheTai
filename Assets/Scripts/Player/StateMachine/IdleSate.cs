using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSate : IState
{
    float time;
    public void OnEnter(PlayerController player)
    {
        player.Idle();
    }

    public void OnExecute(PlayerController player)
    {
        player.FindTarget();
        if (player.Target != null && !player.isMoving)
        {
            player.ChangeState(new AttackState());
        }
        if (player.isMoving)
        {
            player.ChangeState(new RunState());
        }
    }

    public void OnExit(PlayerController player)
    {

    }
}
