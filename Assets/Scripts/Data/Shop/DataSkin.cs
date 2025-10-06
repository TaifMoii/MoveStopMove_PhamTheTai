using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataSkin", menuName = "ScriptableObjects/Skin", order = 1)]

public class DataSkinSO : ScriptableObject
{
    public List<DataSkin> skins = new List<DataSkin>();
}
[System.Serializable]
public class DataSkin
{
    public string skinName;
    public int index;
    public Sprite icon;
    public int price;
    public bool isEquipped = false;
    public bool isPurchased = false;
}