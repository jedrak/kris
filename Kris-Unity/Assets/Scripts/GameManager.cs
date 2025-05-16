using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LevelManager m_LevelManager;
    public LevelManager LevelManager => m_LevelManager;
    
    [SerializeField] private InputManager m_InputManager;
    public InputManager InputMgr => m_InputManager;

    [SerializeField] private PlayerOrigin m_PlayerOrigin;
    public PlayerOrigin PlayerOrigin => m_PlayerOrigin;
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
        HandleInit();
    }

    private void HandleInit()
    {
        m_InputManager.HandleInit();
        m_LevelManager.HandleInit();
        
    }

    public void SubscribePlayer(PlayerOrigin playerOrigin)
    {
        if (m_PlayerOrigin != null)
        {
            Destroy(m_PlayerOrigin);
        }
        m_PlayerOrigin = playerOrigin;
    }
}
