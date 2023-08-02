using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStoryComponentControl
{
    public int componentType;

    public void GetEvent(StoryEvent storyEvent)
    {
        Execute(storyEvent.eventName, storyEvent.componentData, storyEvent.storySceneData);
    }

    public abstract void Execute(string eventName, BaseStoryComponentData componentData, StorySceneData storySceneData);
}
