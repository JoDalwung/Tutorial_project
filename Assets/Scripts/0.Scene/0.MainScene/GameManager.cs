using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IScene
{

    public List<IScene.SceneName> SceneList;    
    public IScene.SceneName EntryScene;

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


    }

    void _RemoveEvent()
    {
    

    }





}
