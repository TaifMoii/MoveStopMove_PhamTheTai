using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int Coin = 500;


    public List<DataWeapon> Weapons;
    public List<DataSkin> Skins;
    public void Init()
    {
        Weapons = new List<DataWeapon>();
        Skins = new List<DataSkin>();
    }
    public void AddWeapon(DataWeapon weapon)
    {
        if (!Weapons.Contains(weapon))
        {
            Weapons.Add(weapon);
        }
    }
    public void AddSkin(DataSkin skin)
    {
        if (!Skins.Contains(skin))
        {
            Skins.Add(skin);

        }
    }
}
public class PlayerDataWrapper
{
    private static PlayerData playerData;
    private const string PlayerDataKey = "PlayerData";
    //chuyen doi tuong PlayerData sang dang json va luu vao PlayerPrefs
    static PlayerDataWrapper()
    {
        playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(PlayerDataKey));

        //neu chua co du lieu thi khoi tao du lieu mac dinh
        if (playerData == null)
        {
            var defaultWeapon = 0;
            var defaultSkin = 0;
            playerData = new PlayerData
            {
                Weapons = new List<DataWeapon> { playerData.Weapons[defaultWeapon] },
                Skins = new List<DataSkin> { playerData.Skins[defaultSkin] }
            };
            SavePlayerData();
        }
    }
    static void SavePlayerData()
    {
        var json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString(PlayerDataKey, json);
    }

    public static void AddWeapon(DataWeapon weapon)
    {
        playerData.AddWeapon(weapon);
        SavePlayerData();
    }
    public static void AddSkin(DataSkin skin)
    {
        playerData.AddSkin(skin);
        SavePlayerData();
    }
}