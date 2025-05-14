using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    
    [SerializeField] private InputManager m_InputManager;
    public InputManager InputMgr => m_InputManager;

    [SerializeField] private LevelBuilder m_LevelBuilder;
    public LevelBuilder LevelBuilder => m_LevelBuilder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
