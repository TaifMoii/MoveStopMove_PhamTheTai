using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopWeapon : UICanvas
{
    [SerializeField] private Button backMainMenu;
    void Awake()
    {
        backMainMenu.onClick.AddListener(BackMainMenu);
    }
    void OnDestroy()
    {
        backMainMenu.onClick.RemoveListener(BackMainMenu);
    }
    public void BackMainMenu()
    {
        GameManager.Ins.OpenMainMenu();
    }
}
