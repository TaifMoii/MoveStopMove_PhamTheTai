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

    private float coin { get; set; }

    void Awake()
    {
        buttonPlay.onClick.AddListener(ButtonPlayClick);
        buttonShopSkin.onClick.AddListener(ButtonSkinClick);
        buttonShopWeapon.onClick.AddListener(ButtonWeaponClick);
    }
    void OnDestroy()
    {
        buttonPlay.onClick.RemoveListener(ButtonPlayClick);
        buttonShopSkin.onClick.RemoveListener(ButtonSkinClick);
        buttonShopWeapon.onClick.RemoveListener(ButtonWeaponClick);
    }
    public void SetCoin()
    {
        coinText.text = coin.ToString();
    }
    public void ButtonPlayClick()
    {
        GameManager.Ins.OpenGamePlay();
    }
    public void ButtonSkinClick()
    {
        GameManager.Ins.OpenSkinShop();
    }
    public void ButtonWeaponClick()
    {
        GameManager.Ins.OpenWeaponShop();
    }
}
