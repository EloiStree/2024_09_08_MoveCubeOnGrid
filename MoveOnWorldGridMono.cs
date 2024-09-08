using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MoveOnWorldGridMono : MonoBehaviour, I_MoveCubeOnGrid
{


    [ContextMenu("Move Forward")]
    public void MoveOneForward() => MoveForward();
    [ContextMenu("Move Backward")]
    public void MoveOneBackward() => MoveBackward();
    [ContextMenu("Move Left")]
    public void MoveOneLeft() => MoveLeft();
    [ContextMenu("Move Right")]
    public void MoveOneRight() => MoveRight();
    [ContextMenu("Move Up")]
    public void MoveOneUp() => MoveUp();
    [ContextMenu("Move Down")]
    public void MoveOneDown() => MoveDown();
    [ContextMenu("Turn Left")]
    public void TurnOneLeft() => TurnLeft90Degree();
    [ContextMenu("Turn Right")]
    public void TurnOneRight() => TurnRight90Degree();


    public abstract void TurnLeft90Degree(int step = 1);

    public void TurnRight90Degree(int step = 1) { TurnLeft90Degree(-step); }


    public abstract void MoveForward(int step = 1);

    public void MoveBackward(int step = 1) { MoveForward(-step); }

    public abstract void MoveRight(int step = 1);

    public void MoveLeft(int step = 1) { MoveRight(-step); }

    public abstract void MoveUp(int step = 1);

    public void MoveDown(int step = 1) { MoveUp(-step); }
}




