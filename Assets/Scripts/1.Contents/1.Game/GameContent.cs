using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContent : IContent
{
    [SerializeField] Text _PlayerCharacter_Name_txt;
    [SerializeField] GameObject[] _Weapon_obj;
    [SerializeField] Transform _Right_Hand_pos;

    public IDialogLoader dialogLoader;


#region Framework
    protected override void _OnLoad()
    {
        dialogLoader.LoadDialog();
    }

    protected override void _OnLoadComplete()
    {
        dialogLoader.ShowIdxDialog(); 
    }

    protected override void _OnEnter()
    {
        _PlayerCharacter_Name_txt.text = PlayerInfo.Instance.Name;
        
        _AddEvent();
    } 
    protected override void _OnExite()
    {
        dialogLoader.UnLoadDialog();
        _RemoveEvent();
    }
    void _AddEvent()
    {
        UIItem.Item_Equipped_act += UIItem_Item_Equipped_act;
        GameDialog.Eq_Item_Sale += GameDialog_Eq_Item_Sale;
    }

    private void GameDialog_Eq_Item_Sale(int obj)
    {
        if (PlayerInfo.Instance.Eq_Item_idx == obj)
        {
            if (_Right_Hand_pos.childCount > 0)
            {
                Destroy(_Right_Hand_pos.GetChild(0).gameObject);
            }
        }

    }

    private void UIItem_Item_Equipped_act(int obj)
    {
        if (_Right_Hand_pos.childCount > 0)
        {
            Destroy(_Right_Hand_pos.GetChild(0).gameObject);
        }
        PlayerInfo.Instance.Eq_Item_idx = obj;
        Instantiate(_Weapon_obj[obj], _Right_Hand_pos);

    }

    void _RemoveEvent()
    {
        UIItem.Item_Equipped_act -= UIItem_Item_Equipped_act; 
        GameDialog.Eq_Item_Sale -= GameDialog_Eq_Item_Sale;
    }
#endregion
}

