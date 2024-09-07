using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("ItemSprite")]
    [SerializeField] Sprite[] _ItemIcon_sp;
    Button[] _Inventory_Item_btns = new Button[5];

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            _Inventory_Item_btns[i] = transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Button>();
        }
    }

    void _LoadItemList()
    {
        for (int i = 0; i < _Inventory_Item_btns.Length; i++)
        {
            _Inventory_Item_btns[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < PlayerInfo.Instance.EquipmentList.Count; i++)
        {
            _Inventory_Item_btns[i].gameObject.SetActive(true);
            _Inventory_Item_btns[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _Inventory_Item_btns[i].image.sprite = _ItemIcon_sp[PlayerInfo.Instance.EquipmentList[i].EquipmentData_Idx];
            _Inventory_Item_btns[i].GetComponent<UIItem>().SetUpItem(PlayerInfo.Instance.EquipmentList[i], i);

        }
    
    }

    private void OnEnable()
    {
        _LoadItemList();
        GameDialog.ReLoadItemList += GameDialog_ReLoadItemList;
    }

    private void GameDialog_ReLoadItemList()
    {
        _LoadItemList();
    }


    private void OnDisable()
    {
        GameDialog.ReLoadItemList -= GameDialog_ReLoadItemList;
    }

}
