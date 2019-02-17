using Minefield.App.Interfaces;
using System;
using System.Collections.Generic;

namespace Minefield.App
{
    public class Chessboard : IBoard
    {
        private IRenderer _renderer;
        private Tile[,] _tiles;
        private Tile _currentTile;
        private Dictionary<int, string> _boardLabelMap;
        private int _boardWidth;
        private int _boardHeight;
        private const int _chanceOfMine = 6;
        private const int _startPosX = 3;
        private const int _startPosY = 0;

        public Chessboard(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Setup(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;

            var tiles = new Tile[_boardWidth, _boardHeight];

            _boardLabelMap = new Dictionary<int, string>()
            {
                { 0, "A"},
                { 1, "B"},
                { 2, "C"},
                { 3, "D"},
                { 4, "E"},
                { 5, "F"},
                { 6, "G"},
                { 7, "H"},
            };

            var rnd = new Random();

            for (var x = 0; x < _boardWidth; x++)
            {
                for (var y = 0; y < _boardHeight; y++)
                {
                    var roll = rnd.Next(1, _chanceOfMine + 1);
                    var rolledMine = roll == _chanceOfMine ? true : false;
                    
                    if (x == _startPosX & y == _startPosY || !rolledMine)
                    {
                        tiles[x, y] = new Tile(x, y, _boardLabelMap[x]);
                    }
                    else
                    {
                        tiles[x, y] = new MineTile(x, y, _boardLabelMap[x]);
                    }
                }
            }

            _tiles = tiles;
            _currentTile = tiles[_startPosX, _startPosY];
            Redraw();
        }

        public void Redraw()
        {
            _renderer.Clear();
            _renderer.DrawHeader();
            _renderer.DrawGrid(_tiles, _currentTile);
            _renderer.DrawCurrentPos(_currentTile);
        }

        public bool ShiftTileLeft()
        {
            if (_currentTile.XPos > 0)
            {
                _currentTile = _tiles[_currentTile.XPos - 1, _currentTile.YPos];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileRight()
        {
            if (_currentTile.XPos < _boardWidth - 1)
            {
                _currentTile = _tiles[_currentTile.XPos + 1, _currentTile.YPos];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileUp()
        {
            if (_currentTile.YPos < _boardHeight - 1)
            {
                _currentTile = _tiles[_currentTile.XPos, _currentTile.YPos + 1];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileDown()
        {
            if (_currentTile.YPos > 0)
            {
                _currentTile = _tiles[_currentTile.XPos, _currentTile.YPos - 1];
                Redraw();
                return true;
            }
            return false;
        }
    }
}
