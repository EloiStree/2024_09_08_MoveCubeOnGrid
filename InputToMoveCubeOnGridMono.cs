using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputToMoveCubeOnGridMono : MonoBehaviour
{
    public MoveOnWorldGridMono m_whatToMoveOnGrid;

    public InputActionReference m_moveLeft;
    public InputActionReference m_moveRight;
    public InputActionReference m_moveBackward;
    public InputActionReference m_moveForward;
    public InputActionReference m_moveDown;
    public InputActionReference m_moveUp;
    public InputActionReference m_rotateLeft;
    public InputActionReference m_rotateRight;


    private void Awake()
    {
        m_moveLeft.action.Enable();
        m_moveRight.action.Enable();
        m_moveBackward.action.Enable();
        m_moveForward.action.Enable();
        m_moveDown.action.Enable();
        m_moveUp.action.Enable();
        m_rotateLeft.action.Enable();
        m_rotateRight.action.Enable();

    }


    public void OnEnable()
    {
        m_moveLeft.action.performed += _ => m_whatToMoveOnGrid.MoveLeft();
        m_moveRight.action.performed += _ => m_whatToMoveOnGrid.MoveRight();
        m_moveBackward.action.performed += _ => m_whatToMoveOnGrid.MoveBackward();
        m_moveForward.action.performed += _ => m_whatToMoveOnGrid.MoveForward();
        m_moveDown.action.performed += _ => m_whatToMoveOnGrid.MoveDown();
        m_moveUp.action.performed += _ => m_whatToMoveOnGrid.MoveUp();
        m_rotateLeft.action.performed += _ => m_whatToMoveOnGrid.TurnLeft90Degree();
        m_rotateRight.action.performed += _ => m_whatToMoveOnGrid.TurnRight90Degree();
    }
    public void OnDisable()
    {
        m_moveLeft.action.performed -= _ => m_whatToMoveOnGrid.MoveLeft();
        m_moveRight.action.performed -= _ => m_whatToMoveOnGrid.MoveRight();
        m_moveBackward.action.performed -= _ => m_whatToMoveOnGrid.MoveBackward();
        m_moveForward.action.performed -= _ => m_whatToMoveOnGrid.MoveForward();
        m_moveDown.action.performed -= _ => m_whatToMoveOnGrid.MoveDown();
        m_moveUp.action.performed -= _ => m_whatToMoveOnGrid.MoveUp();
        m_rotateLeft.action.performed -= _ => m_whatToMoveOnGrid.TurnLeft90Degree();
        m_rotateRight.action.performed -= _ => m_whatToMoveOnGrid.TurnRight90Degree();
    }

}
