using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UICanvas
{
    [SerializeField] private Button backMainMenu;
    [SerializeField] private GameObject UIShopWeapon;
    [SerializeField] private GameObject UIShopSkin;
    [SerializeField] private TextMeshProUGUI coinText;
    void Awake()
    {
        backMainMenu.onClick.AddListener(BackMainMenu);
        UIShopWeapon.SetActive(true);
        UIShopSkin.SetActive(false);
        coinText.text = GameManager.Ins.PlayerData.Coin.ToString();
    }
    void OnDestroy()
    {
        backMainMenu.onClick.RemoveListener(BackMainMenu);
    }
    public void BackMainMenu()
    {
        GameManager.Ins.OpenMainMenu();
        Level.Ins.ResetGame();
    }
    public void ButtonSkinClick()
    {
        UIShopSkin.SetActive(true);
        UIShopWeapon.SetActive(false);
    }
    public void ButtonWeaponClick()
    {
        UIShopWeapon.SetActive(true);
        UIShopSkin.SetActive(false);
    }
}
