using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public TextMeshProUGUI priceText;
    public Image iconImage;
    public Button button;
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
        //kiem tra neu da mua thi khong cho mua nua

    }

    //check neu da mua skin hoac weapon thi tra ve true

}

