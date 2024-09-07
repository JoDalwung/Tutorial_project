using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreItem_Slot : MonoBehaviour, IDropHandler
{
    public static event System.Action StoreItem_Slot_OnDrop_act;


    public void OnDrop(PointerEventData eventData)
    {
        StoreItem_Slot_OnDrop_act?.Invoke();
        // Debug.Log("OnDrop" + name);
        // 상점에 떨어졌을때,
        // 판매가 된다.
        // 상점 리스트에 아이템 정보 추가
        // 플레이어 정보에서 아이템 정보 제외 
        // 판단은 GameDialog.cs 에서

        // 인벤토리 리스트 리로드
        // 상점 리스트 리로드
    }
}
