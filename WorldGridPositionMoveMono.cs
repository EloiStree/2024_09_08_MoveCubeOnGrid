using System;
using UnityEngine;
using UnityEngine.Events;

public enum CubeOnGridRotation {  Forward, Right, Left, Backward}
public class WorldGridPositionMoveMono : MoveOnWorldGridMono
{
    public CubeOnGridRotation m_worldRotationClockwise;
    public int m_rotationStep;
    public int m_xLeftToRight;
    public int m_yDownToUp;
    public int m_zBackToFront;

    public Action m_onChangedAction;
    public UnityEvent m_onChangedEvent;

    public void SetPosition(int x, int y, int z, CubeOnGridRotation rotation) { 
    
        m_xLeftToRight = x;
        m_yDownToUp = y;
        m_zBackToFront = z;
        switch (rotation)
        {
            case CubeOnGridRotation.Forward:
                m_rotationStep = 0;
                break;
            case CubeOnGridRotation.Right:
                m_rotationStep = 1;
                break;
            case CubeOnGridRotation.Backward:
                m_rotationStep = 2;
                break;
            case CubeOnGridRotation.Left:
                m_rotationStep = 3;
                break;
        }
    }

    public void NotifyChanged() 
    {
       if(m_onChangedAction != null)
            m_onChangedAction();
        m_onChangedEvent.Invoke();
    }
    public override void MoveForward(int step = 1)
    {
        if (m_worldRotationClockwise == CubeOnGridRotation.Forward)
            m_zBackToFront += step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Backward)
            m_zBackToFront -= step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Right)
            m_xLeftToRight += step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Left)
            m_xLeftToRight -= step;

        NotifyChanged();
    }

    public override void MoveRight(int step = 1)
    {

        if (m_worldRotationClockwise == CubeOnGridRotation.Forward)
            m_xLeftToRight += step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Backward)
            m_xLeftToRight -= step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Right)
            m_zBackToFront -= step;
        else if (m_worldRotationClockwise == CubeOnGridRotation.Left)
            m_zBackToFront += step;

        NotifyChanged();

    }
    
    public override void MoveUp(int step = 1)
    {

        
        m_yDownToUp += step;
        NotifyChanged();

    }
    public override void TurnLeft90Degree(int step = 1)
    {
        m_rotationStep -= step;
        int rest =m_rotationStep % 4;
        if(rest<0)
            rest += 4;
        if (rest == 0) m_worldRotationClockwise = CubeOnGridRotation.Forward;
        else if (rest == 1 || rest==-1) m_worldRotationClockwise = CubeOnGridRotation.Right;
        else if (rest == 2 || rest == -2) m_worldRotationClockwise = CubeOnGridRotation.Backward;
        else m_worldRotationClockwise= CubeOnGridRotation.Left;
        NotifyChanged();
    }

    public void GetCurrentRotation(out CubeOnGridRotation cubeOnGridRotation)
        => cubeOnGridRotation = m_worldRotationClockwise;

    public void AddChangedListener(Action refreshPosition)
    {
        if (refreshPosition != null)
            m_onChangedAction += refreshPosition;
    }
    public void RemoveChangedListener(Action refreshPosition)
    {
        if (refreshPosition != null)
            m_onChangedAction -= refreshPosition;
    }

}




