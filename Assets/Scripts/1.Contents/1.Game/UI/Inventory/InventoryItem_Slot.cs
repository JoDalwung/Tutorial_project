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
        // �κ��丮�� ����������,
        // ���Ű� �ȴ�.
        // Playerinfo �� ������ ���� �߰�
        // ������ ������ ���� ���� 
        // �κ��丮 ����Ʈ ���ε�
        // ���� ����Ʈ ���ε�
        // �Ǵ��� GameDialog.cs ����
    }
}
