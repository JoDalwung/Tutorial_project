using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IScene
{

    public List<SceneName> SceneList;    
    public SceneName EntryScene;

    protected override void _OnLoad()
    {
        base._OnLoad();
        DontDestroyOnLoad(gameObject);
    }

    protected override void _OnLoadComplete()
    {
        ActiveScene(EntryScene);
    }

    protected override void _OnEnter() => _AddEvent();
    protected override void _OnExite() => _RemoveEvent();

    void _AddEvent()
    {
        LobbyDialog.LobbyToGame_act += LobbyDialog_LobbyToGame_act;

    }

    void _RemoveEvent()
    {
        LobbyDialog.LobbyToGame_act -= LobbyDialog_LobbyToGame_act;

    }

    private void LobbyDialog_LobbyToGame_act()
    {
        ActiveScene(SceneName.GameScene);
    }







}
