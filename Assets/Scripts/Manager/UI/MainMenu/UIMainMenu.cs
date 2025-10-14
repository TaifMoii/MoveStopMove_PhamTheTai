using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UICanvas

{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonShopWeapon;
    [SerializeField] private Button buttonShopSkin;



    public TextMeshProUGUI coinText;


    void Awake()
    {
        buttonPlay.onClick.AddListener(ButtonPlayClick);
        buttonShopSkin.onClick.AddListener(ButtonShopSkinClick);
        buttonShopWeapon.onClick.AddListener(ButtonShopWeaponClick);
    }
    void OnDestroy()
    {
        buttonPlay.onClick.RemoveListener(ButtonPlayClick);
        buttonShopSkin.onClick.RemoveListener(ButtonShopSkinClick);
        buttonShopWeapon.onClick.RemoveListener(ButtonShopWeaponClick);
    }
    public void Update()
    {
        coinText.text = GameManager.Ins.PlayerData.Coin.ToString();
    }

    public void ButtonPlayClick()
    {
        GameManager.Ins.OpenGamePlay();
    }

    public void ButtonShopSkinClick()
    {
        GameManager.Ins.OpenSkinShop();
    }
    public void ButtonShopWeaponClick()
    {
        GameManager.Ins.OpenWeaponShop();
    }
}
