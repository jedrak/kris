using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : AModule
{
    [SerializeField] private LevelBuilder m_Builder;
    [SerializeField] private LevelData m_DefaultLevelData;
    public override void HandleInit()
    {
        base.HandleInit();
        if (m_Builder != null)
        {
            m_Builder.BuildLevel(m_DefaultLevelData);
        }
    }
}
