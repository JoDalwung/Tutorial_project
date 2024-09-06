using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContent : IContent
{
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
        _AddEvent();
    } 
    protected override void _OnExite()
    {
        dialogLoader.UnLoadDialog();
        _RemoveEvent();
    }
    void _AddEvent(){}
    void _RemoveEvent(){}
#endregion
}

