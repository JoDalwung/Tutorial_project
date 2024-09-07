using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

    public static event System.Action<bool> UI_Item_act;
    public static event System.Action<EquipmentData> UI_Item_selectInfo_act;
    public static event System.Action<int> Item_Equipped_act;

    public EquipmentData data;
    public int Idx;



    Button btn;


    void Awake()
    {
        btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(Item_Equipped_btn_evt);
    }

    void Item_Equipped_btn_evt()
    {
        if (data.Collect)
        {
            //장착 이벤트
            // 아이템정보 GameContent에 전달해서 아이템 로드
            Item_Equipped_act?.Invoke(data.EquipmentData_Idx);
        }
        
    }


    public void SetUpItem(EquipmentData o,int n)
    {
        data = o;
        Idx = n;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //to dialog
        UI_Item_act?.Invoke(true);
        UI_Item_selectInfo_act?.Invoke(data);
        //

        //
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Debug.Log("OnBeginDrag");
        //
    }

    public void OnDrag(PointerEventData eventData)
    {
        UI_Item_act?.Invoke(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UI_Item_act?.Invoke(false);
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Debug.Log("OnEndDrag");

    }



}
