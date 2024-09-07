using System.Collections.Generic;

public class PlayerData
{
    public string PlayerData_Name;
    public List<EquipmentData> PlayerData_EquipmentList;
    public int PlayerData_Gold;
}

[System.Serializable]
public class EquipmentData
{
    public string EquipmentData_Name;
    public string EquipmentData_info;
    public int EquipmentData_Gold;
    public int EquipmentData_Idx;
    public bool Collect;

    public EquipmentData(string name = "" , string info = "" , int gold = 0, int idx = 0 , bool _collect = false)
    {
        EquipmentData_Name = name;
        EquipmentData_info = info;
        EquipmentData_Gold = gold;
        EquipmentData_Idx = idx;
        Collect = _collect;
    }

}