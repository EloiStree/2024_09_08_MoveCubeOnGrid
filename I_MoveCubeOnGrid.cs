using UnityEngine;

public interface I_MoveCubeOnGrid {
    public void TurnLeft90Degree( int step = 1);
    public void TurnRight90Degree( int step = 1);
    
    public void MoveForward(int step = 1);
    public void MoveBackward(int step = 1) { MoveForward(-step); }

    public void MoveRight(int step = 1);
    public void MoveLeft(int step = 1) { MoveRight(-step); }

    public void MoveUp(int step = 1);
    public void MoveDown(int step = 1) { MoveUp(-step); }
}




