using Minefield.App.Interfaces;
using System;
using System.Collections.Generic;

namespace Minefield.App
{
    public class Chessboard : IBoard
    {
        private IRenderer _renderer;
        private ITile[,] _tiles;
        private ITile _currentTile;
        private ITile _finishTile;
        private Dictionary<int, string> _boardLabelMap;
        private int _boardWidth;
        private int _boardHeight;
        private const int _chanceOfMine = 6;
        private const int _startPosX = 3;
        private const int _startPosY = 0;
        private const int _endPosY = 7;

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
                { 0, "A"}, { 1, "B"}, { 2, "C"}, { 3, "D"},
                { 4, "E"}, { 5, "F"}, { 6, "G"}, { 7, "H"},
                { 8, "I"}, { 9, "J"}, { 10, "K"}, { 11, "L"},
                { 12, "M"}, { 13, "N"}, { 14, "O"}, { 15, "P"},
                { 16, "Q"}, { 17, "R"}, { 18, "S"}, { 19, "T"},
                { 20, "U"}, { 21, "V"}, { 22, "W"}, { 23, "X"},
                { 24, "Y"}, { 25, "Z"}
            };

            var rnd = new Random();

            for (var x = 0; x < _boardWidth; x++)
            {
                for (var y = 0; y < _boardHeight; y++)
                {
                    //Allocate mines randomly
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

            //Set finish tile
            var randomX = rnd.Next(0, _boardWidth);
            _finishTile = new FinishTile(randomX, _boardHeight, _boardLabelMap[randomX]);
            _tiles[randomX, _endPosY] = _finishTile;

            //Set current tile
            randomX = rnd.Next(0, _boardWidth);
            _currentTile = tiles[randomX, _startPosY];

            Redraw();
        }

        public void Redraw()
        {
            _renderer.Clear();
            _renderer.DrawHeader();
            _renderer.DrawGrid(_tiles, _currentTile, _finishTile);
            _renderer.DrawCurrentPos(_currentTile);
        }

        public bool ShiftTileLeft()
        {
            if (_currentTile.GetXPos() > 0)
            {
                _currentTile = _tiles[_currentTile.GetXPos() - 1, _currentTile.GetYPos()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileRight()
        {
            if (_currentTile.GetXPos() < _boardWidth - 1)
            {
                _currentTile = _tiles[_currentTile.GetXPos() + 1, _currentTile.GetYPos()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileUp()
        {
            if (_currentTile.GetYPos() < _boardHeight - 1)
            {
                _currentTile = _tiles[_currentTile.GetXPos(), _currentTile.GetYPos() + 1];
                Redraw();
                return true;
            }
            return false;
        }

        public bool ShiftTileDown()
        {
            if (_currentTile.GetYPos() > 0)
            {
                _currentTile = _tiles[_currentTile.GetXPos(), _currentTile.GetYPos() - 1];
                Redraw();
                return true;
            }
            return false;
        }

        public ITile GetActiveTile()
        {
            return _currentTile;
        }

        public ITile GetFinishedTile()
        {
            return _finishTile;
        }
    }
}
