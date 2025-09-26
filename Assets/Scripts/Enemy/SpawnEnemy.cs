using System.Collections.Generic;
using UnityEngine;



public class SpawnEnemy : MonoBehaviour
{
    List<EnemyController> enemies = new List<EnemyController>();
    public void SpawnEnemys()
    {
        Vector3 destination = NavMeshUtils.GetRandomPointOnNavMesh();

        var enemy = HBPool.Spawn<EnemyController>(PoolType.None, destination, Quaternion.identity);
        enemies.Add(enemy);
    }


}

