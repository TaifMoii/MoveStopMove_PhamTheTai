using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : IState
{
    public void OnEnter(PlayerController player)
    {
        player.Dance();
    }

    public void OnExecute(PlayerController player)
    {

    }

    public void OnExit(PlayerController player)
    {

    }
}