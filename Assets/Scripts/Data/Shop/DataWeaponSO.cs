using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataWeaponSO", menuName = "ScriptableObjects/Weapon", order = 1)]
public class DataWeaponSO : ScriptableObject
{
    public List<DataWeapon> weapons = new List<DataWeapon>();
}

[System.Serializable]
public class DataWeapon
{
    public int index;
    public string weaponName;
    public Sprite icon;
    public int price;
    public bool isEquipped = false;
    public bool isPurchased = false;
}
