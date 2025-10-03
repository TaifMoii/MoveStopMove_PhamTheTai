using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDeathState : EIState
{
    public void OnEnter(EnemyController enemy)
    {
        enemy.isDead = true;
        enemy.DespawnEnemy();
    }

    public void OnExecute(EnemyController enemy)
    {

    }

    public void OnExit(EnemyController enemy)
    {
    }
}
