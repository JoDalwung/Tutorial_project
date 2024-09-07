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
        // ������ ����������,
        // �ǸŰ� �ȴ�.
        // ���� ����Ʈ�� ������ ���� �߰�
        // �÷��̾� �������� ������ ���� ���� 
        // �Ǵ��� GameDialog.cs ����

        // �κ��丮 ����Ʈ ���ε�
        // ���� ����Ʈ ���ε�
    }
}
