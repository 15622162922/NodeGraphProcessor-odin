using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundComponentData: BaseStoryComponentData
{
    public BackgroundComponentData()
    {
        this.componentType = StoryDefine.ComponentType.Background;
    }

    public string backgroundPath;

    public bool isSlow = false;
    public float slowInTime = 0;
    public float slowOutTime = 0;
}
