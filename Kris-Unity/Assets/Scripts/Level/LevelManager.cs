using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : AModule
{
    [SerializeField] private LevelBuilder m_Builder;
    //move current level to diffrent object
    public LevelBuilder Builder => m_Builder;

    private LevelData m_CurrentLevelData;
    public LevelData CurrentLevelData => m_CurrentLevelData;
    [SerializeField] private LevelData m_DefaultLevelData;
    public override void HandleInit()
    {
        base.HandleInit();
        if (m_Builder != null)
        {
            m_Builder.BuildLevel(m_DefaultLevelData);
            m_CurrentLevelData = m_DefaultLevelData;
        }
    }

    public void SetCurrentLevelData(LevelData levelData)
    {
        m_CurrentLevelData = levelData;
    }
}
