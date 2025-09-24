using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    public void OnEnter(PlayerController player)
    {
        Debug.Log("Dead");
        player.OnDespawn();

    }

    public void OnExecute(PlayerController player)
    {

    }

    public void OnExit(PlayerController player)
    {

    }
}
