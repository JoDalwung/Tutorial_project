using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInfo : Singletion<PlayerInfo>
{
    public string Name;
    public List<EquipmentData> EquipmentList = new List<EquipmentData>();
    public int Gold = 100000;

    //
    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.PlayerData_Name = Name;
        data.PlayerData_EquipmentList = EquipmentList;
        data.PlayerData_Gold = Gold;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.streamingAssetsPath + "/PlayerDataFile.json", json);
    }

    public void LoadData()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/PlayerDataFile.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Name = data.PlayerData_Name;
        EquipmentList = data.PlayerData_EquipmentList;
        Gold = data.PlayerData_Gold;
    }



}
