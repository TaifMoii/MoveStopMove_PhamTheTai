using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponUI : Singleton<ShopWeaponUI>
{
    public DataWeaponSO weaponData;
    public ItemWeapon weaponPrefab;
    public Transform content;

    private List<ItemWeapon> weaponItems = new List<ItemWeapon>();

    void Start()
    {
        foreach (var weapon in weaponData.weapons)
        {
            ItemWeapon newItem = Instantiate(weaponPrefab, content);
            newItem.WeaponInit(weapon);
            weaponItems.Add(newItem);
        }
    }
    public void UpdateWeapon(ItemWeapon item, DataWeapon newWeaponData)
    {
        foreach (var weapon in weaponItems)
        {
            if (weapon != item && weapon.currentType == WeaponType.Equipped)
            {
                weapon.Init(WeaponType.UnEquipped);
                newWeaponData.isEquipped = true;
            }
            if (weapon == item && weapon.currentType == WeaponType.Equipped)
            {
                weapon.Init(WeaponType.Equipped);
                newWeaponData.isEquipped = false;
            }
        }
    }
}
