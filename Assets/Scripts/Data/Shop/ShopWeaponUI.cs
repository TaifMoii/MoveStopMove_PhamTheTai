using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponUI : Singleton<ShopWeaponUI>
{
    public DataWeaponSO weaponData;
    public ItemWeapon weaponPrefab;
    public Transform content;
    public PlayerData playerData;

    private List<ItemWeapon> weaponItems = new List<ItemWeapon>();

    void Start()
    {
        foreach (var weapon in weaponData.weapons)
        {
            ItemWeapon newItem = Instantiate(weaponPrefab, content);
            newItem.WeaponInit(weapon, this);
            weaponItems.Add(newItem);
        }
    }
    public void UpdateWeapon(int id)
    {
        foreach (var weapon in weaponItems)
        {
            if (weapon.weaponData.index != id)
            {
                weapon.SwitchItemType(WeaponType.UnEquipped);
            }
        }
    }

}
