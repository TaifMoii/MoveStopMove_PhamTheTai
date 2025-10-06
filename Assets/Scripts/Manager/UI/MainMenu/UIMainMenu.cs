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
    [SerializeField] private Button buttonShop;

    [SerializeField] private Button buttonInventSkin;
    [SerializeField] private Button buttonInventWeapon;


    public TextMeshProUGUI coinText;

    private float coin { get; set; }

    void Awake()
    {
        buttonPlay.onClick.AddListener(ButtonPlayClick);
        buttonShop.onClick.AddListener(ButtonShopClick);
        buttonInventSkin.onClick.AddListener(ButtonInventSkinClick);
        buttonInventWeapon.onClick.AddListener(ButtonInventWeaponClick);
    }
    void OnDestroy()
    {
        buttonPlay.onClick.RemoveListener(ButtonPlayClick);
        buttonShop.onClick.RemoveListener(ButtonShopClick);
        buttonInventSkin.onClick.RemoveListener(ButtonInventSkinClick);
        buttonInventWeapon.onClick.RemoveListener(ButtonInventWeaponClick);
    }
    public void Update()
    {
        coinText.text = GameManager.Ins.playerData.Coin.ToString();
    }

    public void ButtonPlayClick()
    {
        GameManager.Ins.OpenGamePlay();
    }
    public void ButtonShopClick()
    {
        GameManager.Ins.OpenShop();
    }
    public void ButtonInventSkinClick()
    {
        GameManager.Ins.OpenInventSkin();
    }
    public void ButtonInventWeaponClick()
    {
        GameManager.Ins.OpenInventWeapon();
    }
}
