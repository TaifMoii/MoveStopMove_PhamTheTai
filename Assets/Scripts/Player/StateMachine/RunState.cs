using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    public void OnEnter(PlayerController player)
    {
        player.Run();
    }

    public void OnExecute(PlayerController player)
    {
        if (player.isMoving)
        {
            return;
        }
        else
        {
            player.ChangeState(new IdleSate());
        }

    }

    public void OnExit(PlayerController player)
    {
    }
}
