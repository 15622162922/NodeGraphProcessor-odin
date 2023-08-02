using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventManager
{
    private Dictionary<StoryDefine.ComponentType, BaseStoryComponentControl> controlMap;

    public void Init()
    {
        controlMap = new Dictionary<StoryDefine.ComponentType, BaseStoryComponentControl>();
        recycleEvent = new Queue<StoryEvent>();
        eventList = new Queue<StoryEvent>();
    }

    public void RegisterControl<T>(StoryDefine.ComponentType type) where T:BaseStoryComponentControl
    {
        if(controlMap.ContainsKey(type))
        {
            Debug.LogError("注册了重复的ComponentControl，type为：" + type);
            return;
        }

        controlMap.Add(type, Activator.CreateInstance<T>());
    }

    private Queue<StoryEvent> recycleEvent; //回收空事件
    private Queue<StoryEvent> eventList;    //正在触发的事件

    public void DispatchEvent(string eventName, BaseStoryComponentData componentData, StorySceneData storySceneData)
    {
        StoryEvent _event = GetEvent();
        _event.SetParams(eventName, componentData, storySceneData);
        eventList.Enqueue(_event);
    }

    StoryEvent GetEvent()
    {
        StoryEvent _event = recycleEvent.Dequeue();
        if(_event == null)
        {
            _event = new StoryEvent();
        }

        return _event;
    }

    private void Update() 
    {
        if(eventList.Count > 0)
        {
            StoryEvent _event = eventList.Dequeue();
            StoryDefine.ComponentType componentType = _event.componentData.componentType;
            BaseStoryComponentControl control;
            if(!controlMap.TryGetValue(componentType, out control))
            {
                UnityEngine.Debug.LogError($"未注册componentType为{componentType}的控制器");
                return;
            }
            control.GetEvent(_event);
        }
    }
}

public class StoryEvent
{
    public string eventName;

    public BaseStoryComponentData componentData;

    public StorySceneData storySceneData;

    public void SetParams(string eventName, BaseStoryComponentData componentData, StorySceneData storySceneData)
    {
        this.eventName = eventName;
        this.componentData = componentData;
        this.storySceneData = storySceneData;
    }
}
