using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    public void OnEnter(PlayerController player)
    {
        player.isDead = true;
        player.Dead();
        GameManager.Ins.OpenUILose();
        CooldownUI.Ins.StartCooldown(5);

    }

    public void OnExecute(PlayerController player)
    {

    }

    public void OnExit(PlayerController player)
    {

    }
}
