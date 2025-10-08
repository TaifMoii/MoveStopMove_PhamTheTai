using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System.IO;

public enum GameState { MainMenu, GamePlay, Finish, Revive, Setting }

public class GameManager : Singleton<GameManager>
{
    private static GameState gameState;
    public Canvas joyStick;
    public PlayerData playerData;

    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state) => gameState == state;

    private void Awake()
    {
        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }

        playerData = new PlayerData();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        OpenMainMenu();
    }
    public void OpenMainMenu()
    {
        UIManager.Ins.CloseAll();
        joyStick.gameObject.SetActive(false);
        UIManager.Ins.OpenUI<UIMainMenu>();
        gameState = GameState.MainMenu;
    }
    public void OpenGamePlay()
    {
        UIManager.Ins.CloseAll();
        joyStick.gameObject.SetActive(true);
        Level.Ins.StartGame();
        UIManager.Ins.OpenUI<UIGamePlay>();
        gameState = GameState.GamePlay;

    }
    public void OpenRevive()
    {
        UIManager.Ins.OpenUI<UILose>();
        gameState = GameState.Revive;

    }
    public void OpenSkinShop()
    {
        CameraFollow.Ins.ChangeCamera(CameraState.Shop);
        UIManager.Ins.OpenUI<UIShopSkin>();
    }
    public void OpenWeaponShop()
    {
        CameraFollow.Ins.ChangeCamera(CameraState.Shop);
        UIManager.Ins.OpenUI<UIShopWeapon>();
    }
    public void OpenUILose()
    {
        UIManager.Ins.OpenUI<UILose>();
    }
    public void OpenUIWin()
    {
        UIManager.Ins.OpenUI<UIWin>();
    }
    public void OpenShop()
    {
        UIManager.Ins.OpenUI<UIShop>();
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameManager.Ins.playerData = JsonUtility.FromJson<PlayerData>(json);
        }
    }
    public void SavePlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        string json = JsonUtility.ToJson(GameManager.Ins.playerData);
        File.WriteAllText(path, json);
    }
    public void Delete()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
