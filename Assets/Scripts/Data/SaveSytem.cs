using UnityEngine;
using System.IO;
public class SaveSytem : MonoBehaviour
{
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameManager.Ins.PlayerData = JsonUtility.FromJson<PlayerData>(json);
        }
    }
    public void SavePlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        string json = JsonUtility.ToJson(GameManager.Ins.PlayerData);
        File.WriteAllText(path, json);
    }
    public void Delete()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
