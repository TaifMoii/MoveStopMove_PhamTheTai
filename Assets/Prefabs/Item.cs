using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public Image iconImage;

    DataWeapon weaponData;
    DataSkin skinData;

    public void WeaponInit(DataWeapon weaponDatas)
    {
        weaponData = weaponDatas;
        iconImage.sprite = weaponData.icon;
        priceText.text = weaponData.price.ToString();
    }
    public void SkinInit(DataSkin skinDatas)
    {
        skinData = skinDatas;
        iconImage.sprite = skinData.icon;
        priceText.text = skinData.price.ToString();
    }
    public void OnClick()
    {
        if (weaponData != null)
        {
            if (GameManager.Ins.playerData.Coin >= weaponData.price && !GameManager.Ins.playerData.Weapons.Contains(weaponData))
            {
                GameManager.Ins.playerData.Coin -= weaponData.price;
                GameManager.Ins.playerData.Weapons.Add(weaponData);
                GameManager.Ins.SavePlayerData();
                GameManager.Ins.LoadPlayerData();
                GameManager.Ins.OpenMainMenu();
            }
        }
        if (skinData != null)
        {
            if (GameManager.Ins.playerData.Coin >= skinData.price && !GameManager.Ins.playerData.Skins.Contains(skinData))
            {
                GameManager.Ins.playerData.Coin -= skinData.price;
                GameManager.Ins.playerData.Skins.Add(skinData);
                GameManager.Ins.SavePlayerData();
                GameManager.Ins.LoadPlayerData();
                GameManager.Ins.OpenMainMenu();
            }
        }

    }

}

