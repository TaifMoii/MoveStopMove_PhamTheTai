using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    [SerializeField] DataSkinSO skinData;
    [SerializeField] DataWeaponSO weaponData;
    public int Coin;
    public SkinnedMeshRenderer material;
    // todo : list<int>QA va weapon da mua
    // bien int la nhung thu dang mac

    public List<int> purchasedSkins = new List<int>();
    public List<int> purchasedWeapons = new List<int>();
    public List<Material> materialsLists = new List<Material>();
    public int materialEquip;
    public int skinEquip;

    public int weaponEquip;
    // check neu id cua do co trong list thi la da mua roi
    // neu khong co thi chua mua


    //neu mua thi add vao list
    //neu muon mac thi add id do vao bien int
    // neu muon doi thi thay id do bang id khac

    //neu chua mua thi khong the mac
    //neu mua roi thi co the mac
    //neu muon mac thi phai check xem da co cai khac dang mac chua


    // check neu id bang id do dang mac thi la dang mac
    // neu khong bang thi la khong mac

    public void Awake()
    {

    }
    public void ChangeMaterial()
    {
        if (material != null && materialEquip >= 0 && materialEquip < materialsLists.Count)
        {
            material.material = materialsLists[materialEquip];
        }
    }

    public void BuyWeapon(int id)
    {
        if (CheckWeaponHasBought(id))
        {
            Debug.Log("Is purchased");
            return;
        }
        purchasedWeapons.Add(id);
        Debug.Log("Purchased");

    }
    public void BuySkin(int id)
    {
        if (CheckSkinHasBought(id))
        {
            Debug.Log("Is purchased");
            return;
        }
        purchasedSkins.Add(id);
        Debug.Log("Purchased");

    }

    public bool CheckWeaponHasBought(int id)
    {

        for (int i = 0; i < weaponData.weapons.Count; i++)
        {
            if (i == id)
            {
                return true;
            }
        }
        return false;

    }
    public bool CheckSkinHasBought(int id)
    {
        for (int i = 0; i < skinData.skins.Count; i++)
        {
            if (i == id)
            {
                return true;
            }
        }
        return false;
    }
    public void EquipSkin(int id)
    {
        if (!CheckSkinHasBought(id))
        {
            return;
        }
        if (skinEquip != id)
        {
            skinEquip = id;
            materialEquip = id;
            ChangeMaterial();
        }
        else
        {
            ChangeMaterial();
            Debug.Log("Is Using !");
        }
    }
    public void EquipWeapon(int id)
    {
        if (!CheckWeaponHasBought(id))
        {
            return;
        }
        if (weaponEquip != id)
        {
            weaponEquip = id;
        }
        else
        {
            Debug.Log("Is Using !");
        }
    }
}
