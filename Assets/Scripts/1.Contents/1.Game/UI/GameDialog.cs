using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDialog : IDialog
{
    [Header("ItemSprite")]
    [SerializeField] Sprite[] _ItemIcon_sp;

    [Header("UI")]
    [SerializeField] Button _Inventory_btn;
    [SerializeField] Button _Store_btn;
    [SerializeField] RectTransform _Inventory_rect;    
    [SerializeField] RectTransform _Store_rect;

    [Header("Hovering_Icon")]
    [SerializeField] RectTransform _hovering_Icon_rect;
    [SerializeField] Image _hovering_Icon_img;
    [SerializeField] Text _hovering_Icon_Name_txt;
    [SerializeField] Text _hovering_Icon_info_txt;


    // logic
    public static event System.Action ReLoadItemList;
    Camera _UICam;
    bool _ItemDrag = false;
    EquipmentData _SelectItemData = new EquipmentData();
    StoreManager _SelectItemStoreMgr;


    #region Framework
    protected override void _OnLoad()
    {
        // ui caching
        _UICam = GameObject.Find("UICamera").GetComponent<Camera>();
    }
    protected override void _OnLoadComplete()
    {
        // ui caching Complete
        _Inventory_btn.onClick.AddListener(_Inventory_btn_evt);
        _Store_btn.onClick.AddListener(_Store_btn_evt);

    }

    protected override void _OnEnter()
    {
        _AddEvent();      
    }

    void _Inventory_btn_evt()
    {
        if(!_Inventory_rect.gameObject.activeSelf)
            _Inventory_rect.gameObject.SetActive(true);
        else
            _Inventory_rect.gameObject.SetActive(false);
    }

    void _Store_btn_evt()
    {
        if (!_Store_rect.gameObject.activeSelf)
        {
            _Store_rect.gameObject.SetActive(true);
            _SelectItemStoreMgr = _Store_rect.GetComponent<StoreManager>();
            // 상점을 여러개 추가해도 문제없다.
        }
        else
        {
            _Store_rect.gameObject.SetActive(false);
            _SelectItemStoreMgr = null;
        }
    }


    protected override void _OnExite()
    {
        _RemoveEvent();
    }

    void _AddEvent()
    {
        UIItem.UI_Item_act += UIItem_UI_Item_act;
        UIItem.UI_Item_selectInfo_act += UIItem_UI_Item_selectInfo_act;
        //
        InventoryItem_Slot.InventoryItem_Slot_OnDrop_act += InventoryItem_Slot_InventoryItem_Slot_OnDrop_act;
        StoreItem_Slot.StoreItem_Slot_OnDrop_act += StoreItem_Slot_StoreItem_Slot_OnDrop_act;

    }


    public static event System.Action<int> Eq_Item_Sale; 

    private void StoreItem_Slot_StoreItem_Slot_OnDrop_act() // 판매
    {
        _ItemDrag = false;
        _hovering_Icon_rect.gameObject.SetActive(false);

        if (_SelectItemData.Collect == true)
        {          

            Eq_Item_Sale?.Invoke(_SelectItemData.EquipmentData_Idx);// 입고있는 장비 판매할경우

            //InventoryItem_Slot_InventoryItem_Slot_OnDrop_act 와 반대
            _SelectItemData.Collect = false;
            PlayerInfo.Instance.EquipmentList.Remove(_SelectItemData);
            _SelectItemStoreMgr._StoreItemList.Add(_SelectItemData);
           
            ReLoadItemList?.Invoke();
        }
        else
        { 
        
        }
    }



    private void InventoryItem_Slot_InventoryItem_Slot_OnDrop_act() // 구입
    {
        _ItemDrag = false;
        _hovering_Icon_rect.gameObject.SetActive(false);
        if (_SelectItemData.Collect == false)
        {
            _SelectItemData.Collect = true;
            
            // 데이터 교환
            // 판매풀가 가능 여부도 여기서 판단
            PlayerInfo.Instance.EquipmentList.Add(_SelectItemData); // 플레이어 정보에 인벤토리 아이템 추가
            _SelectItemStoreMgr._StoreItemList.Remove(_SelectItemData); // 팝업창에 올라온 상점의 매물 삭제

            // 인벤토리 리로드 이벤트
            // 상점 리로드 이벤트
            ReLoadItemList?.Invoke();
        }
        else
        { 
            // do noting
        
        }

    }

    private void UIItem_UI_Item_act(bool obj)
    {
        _ItemDrag = obj;
        _hovering_Icon_rect.gameObject.SetActive(obj);
        if (obj == false)
            _SelectItemData = new EquipmentData();

    }
    private void UIItem_UI_Item_selectInfo_act(EquipmentData arg1)
    {
        _SelectItemData = arg1;
        _hovering_Icon_img.sprite = _ItemIcon_sp[_SelectItemData.EquipmentData_Idx];
        _hovering_Icon_Name_txt.text = _SelectItemData.EquipmentData_Name;
        _hovering_Icon_info_txt.text = _SelectItemData.EquipmentData_info;
    }

    void _RemoveEvent()
    {
        UIItem.UI_Item_act -= UIItem_UI_Item_act;
        UIItem.UI_Item_selectInfo_act -= UIItem_UI_Item_selectInfo_act;
        //
        InventoryItem_Slot.InventoryItem_Slot_OnDrop_act -= InventoryItem_Slot_InventoryItem_Slot_OnDrop_act;
        StoreItem_Slot.StoreItem_Slot_OnDrop_act -= StoreItem_Slot_StoreItem_Slot_OnDrop_act;

    }
    #endregion

    private void Update()
    {
        if (_ItemDrag)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = _UICam.nearClipPlane;
            _hovering_Icon_rect.position = _UICam.ScreenToWorldPoint(mousePos) + new Vector3(10, -20, 0);
        }

    }



}

