using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMainMenuState : EIState
{
    public void OnEnter(EnemyController enemy)
    {
        enemy.isMainMenu = true;
        enemy.Dance();
    }

    public void OnExecute(EnemyController enemy)
    {

    }

    public void OnExit(EnemyController enemy)
    {

    }
}
