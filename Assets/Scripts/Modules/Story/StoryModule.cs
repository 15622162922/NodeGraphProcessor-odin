using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModule : BaseModule
{
    StoryEventManager storyEventManager;
    
    public override void Register()
    {
        RegisterController();
    }

    public override void UnRegister()
    {
        
    }

    public void RegisterController()
    {
        storyEventManager = new StoryEventManager();
        storyEventManager.Init();

        storyEventManager.RegisterControl<BackgroundComponentControl>(StoryDefine.ComponentType.Background); //背景控制器
    }

    public void PlayTestStory()
    {

    }

    public void PlayStory(string storyId)
    {

    }
}
