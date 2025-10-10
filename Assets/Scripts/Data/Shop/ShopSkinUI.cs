using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkinUI : Singleton<ShopSkinUI>
{
    public List<ItemSkin> skins = new List<ItemSkin>();
    public DataSkinSO skinData;

    public ItemSkin skinPrefab;
    public Transform content;
    void Start()
    {
        foreach (var skin in skinData.skins)
        {
            ItemSkin newItem = Instantiate(skinPrefab, content);
            newItem.SkinInit(skin, this);
            skins.Add(newItem);
        }
    }
    public void UpdateSkin(int id)
    {
        foreach (var skin in skins)
        {
            Debug.Log("Update Skin UI" + id + " - " + skin.skinData.index);

            if (skin.skinData.index != id)
            {
                skin.SwitchItemType(ItemType.UnEquipped);
            }
        }
    }
}
