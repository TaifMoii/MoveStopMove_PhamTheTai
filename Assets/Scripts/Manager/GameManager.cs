using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public enum GameState { MainMenu, GamePlay, Finish, Revive, Setting }

public class GameManager : Singleton<GameManager>
{
    private static GameState gameState;
    public Canvas joyStick;

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
        Level.Ins.MainMenu();
    }
    public void OpenGamePlay()
    {
        UIManager.Ins.CloseAll();
        joyStick.gameObject.SetActive(true);
        UIManager.Ins.OpenUI<UIGamePlay>();
        gameState = GameState.GamePlay;
        Level.Ins.StartGame();

    }
    public void OpenRevive()
    {
        UIManager.Ins.OpenUI<UILose>();
        gameState = GameState.Revive;
    }
    public void OpenSkinShop()
    {
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIShopSkin>();
    }
    public void OpenWeaponShop()
    {
        UIManager.Ins.CloseAll();
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
}
