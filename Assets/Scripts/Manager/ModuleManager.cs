using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager 
{
    public ModuleManager()
    {
        Init();
    }

    Dictionary<string, BaseModule> modules;

    public void Init()
    {
        modules = new Dictionary<string, BaseModule>();

        RegisterModule<StoryModule>("StoryModule");
    }

    public void Destroy()
    {
    
    }

    public T GetModule<T>(string moduleName) where T : BaseModule
    {
        BaseModule module;
        if(modules.TryGetValue(moduleName, out module))
        {
            return (T)module;
        }
        else
        {
            UnityEngine.Debug.LogError($"获取错误的模块，moduleName = {moduleName}");
            return null;
        }
    }
    
    void RegisterModule<T>(string moduleName) where T : BaseModule
    {
        BaseModule module;
        if(!modules.TryGetValue(moduleName, out module))
        {
            module = System.Activator.CreateInstance<T>();
            module.Register();
            modules.Add(moduleName, module);
        }
    }

    void UnRegisterModule(string moduleName)
    {
        BaseModule module;
        if(modules.TryGetValue(moduleName, out module))
        {
            modules.Remove(moduleName);
        }
    }
}
