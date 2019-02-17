using Minefield.App;
using Minefield.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minefield.Tests.MockObjects
{
    public class MockBoard : IBoard
    {
        private ITile[,] _tiles;
        private ITile _currentTile;
        private ITile _finishTile;
        private int _boardWidth;
        private int _boardHeight;

        public ITile GetActiveTile()
        {
            return new Tile(0, 0);
        }

        public ITile GetFinishedTile()
        {
            return new Tile(0, 0);
        }

        public void GetMineProximity()
        {
        }

        public void Setup(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;
            _tiles = new Tile[_boardWidth, _boardHeight];
            _currentTile = new FinishTile(0, 0);
            _finishTile = new FinishTile(width == 0 ? 0 : 1, 0);
        }

        public bool ShiftTileDown()
        {
            return true;
        }

        public bool ShiftTileLeft()
        {
            return true;
        }

        public bool ShiftTileRight()
        {
            return true;
        }

        public bool ShiftTileUp()
        {
            return true;
        }
    }
}
