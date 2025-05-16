using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InputManager : AModule
{
    public Vector2 MoveInput { get; private set; }
    [SerializeField] private InputActionAsset m_PlayerControlls;
    [SerializeField] private string m_PlayerActionMapName = "Player";
    [SerializeField] private string m_PlayerMoveActionName = "Move";
    
    private InputAction m_MoveAction;


    private float m_Timer;
    [SerializeField] private float m_SnapInterval = 1f;

    public override void HandleInit()
    {
        base.HandleInit();
        m_MoveAction = m_PlayerControlls.FindActionMap(m_PlayerActionMapName).FindAction(m_PlayerMoveActionName);
        RegisterInputActions();
    }

    private void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_SnapInterval && MoveInput != Vector2.zero)
        {
            m_Timer = 0f;
//            Debug.Log(MoveInput.ToString());
            GameManager.Instance.PlayerOrigin.UpdatePosition(MoveInput);
            
        }
    }

    private void OnEnable()
    {
        m_MoveAction.Enable();
    }

    private void OnDisable()
    {
        m_MoveAction.Disable();
    }

    private void RegisterInputActions()
    {
        m_MoveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        m_MoveAction.canceled += context => MoveInput = Vector2.zero;
    }
}

