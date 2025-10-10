using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    [SerializeField] DataSkinSO skinData;
    [SerializeField] DataWeaponSO weaponData;
    public int Coin;
    // todo : list<int>QA va weapon da mua
    // bien int la nhung thu dang mac
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
    public List<int> purchasedSkins = new List<int>();
    public List<int> purchasedWeapons = new List<int>();

    public void Init()
    {
        Coin = 1000; //khoi tao so coin ban dau
    }

    public DataSkin GetDataSkin(int index)
    {
        DataSkin found = skinData.skins.Find(skin => skin.index == index);

        if (found == null)
        {
            Debug.LogWarning("Skin with index " + index + " not found.");
            found = skinData.skins[0]; // Hoặc xử lý khác nếu không tìm thấy
        }
        return found;
    }
    public DataWeapon GetDataWeapon(int index)
    {
        DataWeapon found = weaponData.weapons.Find(weapon => weapon.index == index);

        if (found == null)
        {
            Debug.LogWarning("Weapon with index " + index + " not found.");
            found = weaponData.weapons[0]; // Hoặc xử lý khác nếu không tìm thấy
        }
        return found;
    }
}
