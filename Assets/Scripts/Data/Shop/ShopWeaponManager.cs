using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponManager : MonoBehaviour
{
    public DataWeaponSO weaponData;
    public Item weaponPrefab;
    public Transform content;
    void Start()
    {
        foreach (var weapon in weaponData.weapons)
        {
            Item newItem = Instantiate(weaponPrefab, content);
            newItem.WeaponInit(weapon);
        }
    }
}
