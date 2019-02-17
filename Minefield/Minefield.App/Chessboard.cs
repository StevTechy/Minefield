using Minefield.App.Interfaces;
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

            for (var x = 0; x < _boardWidth; x++)
            {
                for (var y = 0; y < _boardHeight; y++)
                {
                    tiles[x, y] = new Tile(x, y, _boardLabelMap[x]);
                }
            }

            _tiles = tiles;
            _currentTile = tiles[3,0];
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
