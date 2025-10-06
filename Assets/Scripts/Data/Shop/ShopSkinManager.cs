using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkinManager : MonoBehaviour
{
    public DataSkinSO skinData;
    public Item skinPrefab;
    public Transform content;
    void Start()
    {
        foreach (var skin in skinData.skins)
        {
            Item newItem = Instantiate(skinPrefab, content);
            newItem.SkinInit(skin);
        }
    }
}
