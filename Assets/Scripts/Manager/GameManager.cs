using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ModuleManager Modules;

    void Awake()
    {
        Instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        Modules = new ModuleManager();
    }
}
