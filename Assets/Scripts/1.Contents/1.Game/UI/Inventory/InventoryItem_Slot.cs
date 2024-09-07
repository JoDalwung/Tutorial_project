using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem_Slot : MonoBehaviour, IDropHandler
{

    public static event System.Action InventoryItem_Slot_OnDrop_act;

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem_Slot_OnDrop_act?.Invoke();
        // 인벤토리에 떨어졌을때,
        // 구매가 된다.
        // Playerinfo 에 아이템 정보 추가
        // 상점에 아이템 정보 제외 
        // 인벤토리 리스트 리로드
        // 상점 리스트 리로드
        // 판단은 GameDialog.cs 에서
    }
}
