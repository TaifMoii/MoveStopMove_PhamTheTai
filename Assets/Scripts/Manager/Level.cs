using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using UnityEngine;

public class Level : Singleton<Level>
{

    public int maxEnemy;
    public int enemySpawn;
    public int maxEnemySpawn;
    private int maxEnemyIndex;
    private int maxEnemySpawnIndex;

    public PlayerController player;
    public ChangeCamera changeCamera;
    [SerializeField] private List<EnemyController> enemies = new List<EnemyController>();
    public void SpawnEnemy()
    {
        Vector3 destination = NavMeshUtils.GetRandomPointOnNavMesh();
        var enemy = HBPool.Spawn<EnemyController>(PoolType.Enemy, destination, Quaternion.identity);
        enemies.Add(enemy);
        enemy.OnInit(enemy.transform.position);
        enemySpawn++;
    }

    public void Lose()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].isDead == false)
            {
                enemies[i].MainMenu();
            }
        }
        GameManager.Ins.OpenMainMenu();
        ResetGame();
    }
    public void OnInit()
    {
        maxEnemyIndex = maxEnemy;
        maxEnemySpawnIndex = maxEnemySpawn;
    }
    public void ResetGame()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].DespawnEnemy();
            }
        }
        maxEnemy = maxEnemyIndex;
        maxEnemySpawn = maxEnemySpawnIndex;
        enemySpawn = 0;
        player.ResetScore();
    }

    public void StartGame()
    {
        for (int i = 0; i < maxEnemySpawn; i++)
        {
            SpawnEnemy();
        }
        player.ChangeGamePLay();
        changeCamera.ChangeCamPlay();
        OnInit();
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
        if (maxEnemy == 1)
        {
            GameManager.Ins.OpenUIWin();
        }
    }
    public void MainMenu()
    {
        player.OnInit(player.transform.position);
        changeCamera.ChangeCamMenu();
    }

}
