using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateManager 
{
    private static UpdateManager _instance;
    public static UpdateManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new UpdateManager();
                _instance.Init();
            }
            return _instance;
        }        
    }

    private List<Action> updateActionList;
    private List<Action> lateUpdateActionList;
    private List<Action> fixedUpdateActionList;

    public void Init()
    {
        updateActionList = new List<Action>();
        lateUpdateActionList = new List<Action>();
        fixedUpdateActionList = new List<Action>();
    }

    public void RegisterUpdate(Action action)
    {
        if( updateActionList.Contains(action))
        {
            Debug.LogError("重复添加Update函数");
            return;
        }

        updateActionList.Add(action);
    }

    public void RemoveUpdate(Action action)
    {
        if(!updateActionList.Contains(action))
        {
            Debug.LogError("没有找到需要移除的Update函数");
            return;
        }

        updateActionList.Remove(action);
    }


    public void RegisterLateUpdate(Action action)
    {
        if( lateUpdateActionList.Contains(action))
        {
            Debug.LogError("重复添加Update函数");
            return;
        }

        lateUpdateActionList.Add(action);
    }

    public void RemoveLateUpdate(Action action)
    {
        if(!lateUpdateActionList.Contains(action))
        {
            Debug.LogError("没有找到需要移除的Update函数");
            return;
        }

        lateUpdateActionList.Remove(action);
    }


    public void RegisterFixedUpdate(Action action)
    {
        if( fixedUpdateActionList.Contains(action))
        {
            Debug.LogError("重复添加Update函数");
            return;
        }

        fixedUpdateActionList.Add(action);
    }

    public void RemoveFixedUpdate(Action action)
    {
        if(!fixedUpdateActionList.Contains(action))
        {
            Debug.LogError("没有找到需要移除的Update函数");
            return;
        }

        fixedUpdateActionList.Remove(action);
    }

    public void Update() 
    {
        if(updateActionList.Count > 0)
        {
            foreach(var action in updateActionList)
            {
                action.Invoke();
            }
        }
    }

    public void LateUpdate() 
    {
        if(lateUpdateActionList.Count > 0)
        {
            foreach(var action in lateUpdateActionList)
            {
                action.Invoke();
            }
        }
    }

    public void FixedUpdate()
    {
        if(fixedUpdateActionList.Count > 0)
        {
            foreach(var action in fixedUpdateActionList)
            {
                action.Invoke();
            }
        }
    }
}
