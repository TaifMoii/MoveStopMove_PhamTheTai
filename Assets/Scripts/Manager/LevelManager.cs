using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] Level[] levels;
    public Level currentLevel;
    public PlayerController player;
    List<EnemyController> bots = new List<EnemyController>();
    int level = 0;

    public void Start()
    {
        OnLoadLevel(level);
        OnInit();
    }

    //khoi tao trang thai bat dau game
    public void OnInit()
    {
        // player.OnInit();
    }

    //goi khi bat dau gameplay
    public void OnPlay()
    {

    }

    //reset trang thai khi ket thuc game
    public void OnDespawn()
    {
        player.Dead();
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].Dead();
        }

        bots.Clear();
        // SimplePool.CollectAll();
    }

    //tao prefab level moi
    public void OnLoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }

        currentLevel = Instantiate(levels[level]);
    }


    public void OnWin()
    {

    }

    public void OnLose()
    {

    }

    // public void CollectItem(Item item)
    // {

    // }

    public void OnNextLevel()
    {
        OnDespawn();
        OnLoadLevel(++level);
        OnInit();
    }

}
