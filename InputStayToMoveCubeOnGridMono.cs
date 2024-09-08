using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputStayToMoveCubeOnGridMono : MonoBehaviour
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

    public float m_timeBetweenCheckMove = 0.5f;
    public float m_timeBetweenCheckRotate = 0.5f;



    public TimePressEvent m_moveLeftTick;
    public TimePressEvent m_moveRightTick;
    public TimePressEvent m_moveBackwardTick;
    public TimePressEvent m_moveForwardTick;
    public TimePressEvent m_moveDownTick;
    public TimePressEvent m_moveUpTick;
    public TimePressEvent m_rotateLeftTick;
    public TimePressEvent m_rotateRightTick;

    [System.Serializable]
    public class TimePressEvent {

        public float m_timePressed;
        public bool m_isPressed;
        public void AddTime(float addTime, float timeToTick, out bool tick) {
            float previous = m_timePressed;
            m_timePressed = previous +addTime;
            float modNew = m_timePressed % timeToTick;
            float modPrev = previous % timeToTick;
            tick = modNew < modPrev;
        }
        public void SetToReleasedState() {
            m_isPressed = false;
            m_timePressed = 0;
        }
    }

    public void Update()
    {
        CheckFor(m_moveLeft, m_moveLeftTick, () => m_whatToMoveOnGrid.MoveLeft(), m_timeBetweenCheckMove);
        CheckFor(m_moveRight, m_moveRightTick, () => m_whatToMoveOnGrid.MoveRight(), m_timeBetweenCheckMove);
        CheckFor(m_moveBackward, m_moveBackwardTick, () => m_whatToMoveOnGrid.MoveBackward(), m_timeBetweenCheckMove);
        CheckFor(m_moveForward, m_moveForwardTick, () => m_whatToMoveOnGrid.MoveForward(), m_timeBetweenCheckMove);
        CheckFor(m_moveDown, m_moveDownTick, () => m_whatToMoveOnGrid.MoveDown(), m_timeBetweenCheckMove);
        CheckFor(m_moveUp, m_moveUpTick, () => m_whatToMoveOnGrid.MoveUp(), m_timeBetweenCheckMove);
        CheckFor(m_rotateLeft, m_rotateLeftTick, () => m_whatToMoveOnGrid.TurnLeft90Degree(), m_timeBetweenCheckRotate);
        CheckFor(m_rotateRight, m_rotateRightTick, () => m_whatToMoveOnGrid.TurnRight90Degree(), m_timeBetweenCheckRotate);
    }

    private void CheckFor(InputActionReference reference, TimePressEvent stateKeeper, Action action, float timeToCheck)
    {
        bool isPressed = reference.action.ReadValue<float>() > 0.5f;
        if (isPressed)
        {
            stateKeeper.AddTime(Time.deltaTime, timeToCheck, out bool tick);
            if (tick)
                action();
        }
        else stateKeeper.SetToReleasedState();
    }

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

}
