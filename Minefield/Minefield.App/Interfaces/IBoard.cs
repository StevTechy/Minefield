﻿namespace Minefield.App
{
    public interface IBoard
    {
        void Setup(int width, int height);
        bool ShiftTileUp();
        bool ShiftTileDown();
        bool ShiftTileLeft();
        bool ShiftTileRight();
    }
}
