using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Level : Singleton<Level>
{
    public int maxEnemy;
    public int enemySpawn;
    public int maxEnemySpawn;
    List<EnemyController> enemies = new List<EnemyController>();

    public void SpawnEnemy()
    {
        Vector3 destination = NavMeshUtils.GetRandomPointOnNavMesh();
        var enemy = HBPool.Spawn<EnemyController>(PoolType.Enemy, destination, Quaternion.identity);
        enemies.Add(enemy);
        enemy.OnInit(enemy.transform.position);
        enemySpawn++;
    }


    public void StartGame()
    {
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemy();
        }
    }
    public void UpdateEnemy()
    {

        if (enemySpawn < maxEnemySpawn)
        {
            SpawnEnemy();
        }
        maxEnemy--;
        if (maxEnemy <= maxEnemySpawn)
        {
            maxEnemySpawn = maxEnemy;
        }
    }
}
