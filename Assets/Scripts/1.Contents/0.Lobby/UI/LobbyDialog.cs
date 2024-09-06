using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDialog : IDialog
{

    [Header("UI_RectTransform")]
    [SerializeField] RectTransform _NicNamePopUp_rect;
    [Header("UI_Button")]
    [SerializeField] Button _Start_btn;
    [SerializeField] Button _Yes_btn;
    [Header("UI_InputField")]
    [SerializeField] InputField _InputField;

    protected override void _OnLoad()
    {
        // caching 
        _Start_btn.onClick.AddListener(_Start_btn_evt);
        _Yes_btn.onClick.AddListener(_Yes_btn_evt);
    }
    protected override void _OnLoadComplete()
    {
        // Caching Complete
    }

    protected override void _OnEnter()
    {
        _Init();
    }

    void _Init()
    {
        _NicNamePopUp_rect.gameObject.SetActive(false);
    }

    void _Start_btn_evt()
    {

    }

    void _Yes_btn_evt()
    {

    }



    protected override void _OnExite()
    {
        _RemoveEvent();
    }

    void _AddEvent()
    {

    }

    void _RemoveEvent()
    {
      


    }

}
