using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int Coin = 500;

    public List<DataWeapon> Weapons = new List<DataWeapon>();
    public List<DataSkin> Skins = new List<DataSkin>();
}
