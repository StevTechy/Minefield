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
        private const int _randomNumberMatch = 6;
        private const int _startPosY = 0;

        public Chessboard(IRenderer renderer)
        {
            _renderer = renderer;
        }

        private void GenerateBoardLabelMap()
        {
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
        }

        private int GetRandomNumber(int min = 0, int max = 0)
        {
            return new Random().Next(min, max);
        }

        public ITile[,] GenerateTiles(int boardWidth, int boardHeight, int startPosX = 0)
        {
            var tiles = new ITile[boardWidth, boardHeight];

            if(_boardLabelMap == null) GenerateBoardLabelMap();

            for (var x = 0; x < boardWidth; x++)
            {
                for (var y = 0; y < boardHeight; y++)
                {
                    //Allocate mines randomly
                    var rolledMine = GetRandomNumber(1, _randomNumberMatch + 1) == _randomNumberMatch ? true : false;

                    if (x == startPosX & y == _startPosY || !rolledMine)
                    {
                        tiles[x, y] = new Tile(x, y, _boardLabelMap[x]);
                    }
                    else
                    {
                        tiles[x, y] = new MineTile(x, y, _boardLabelMap[x]);
                    }
                }
            }

            return tiles;
        }

        public ITile GenerateFinishTile(int endPosX, int boardHeight)
        {
            if (_boardLabelMap == null) GenerateBoardLabelMap();

            return new FinishTile(endPosX, boardHeight - 1, _boardLabelMap[endPosX]);
        }

        public void Setup(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;

            var startPosX = GetRandomNumber(0, _boardWidth);
            var endPosX = GetRandomNumber(0, _boardWidth);
            var endPosY = height - 1;

            _tiles = GenerateTiles(_boardWidth, _boardHeight, startPosX);

            //Set start tile
            _currentTile = _tiles[startPosX, _startPosY];

            //Set finish tile
            _finishTile = GenerateFinishTile(endPosX, _boardHeight);
            _tiles[endPosX, endPosY] = _finishTile;
            
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

        public void SetActiveTile(int xPos, int yPos)
        {
            _currentTile = _tiles[xPos, yPos];
        }

        public ITile GetActiveTile()
        {
            return _currentTile;
        }

        public ITile GetFinishedTile()
        {
            return _finishTile;
        }
        
        public void GetMineProximity()
        {
            int xPos = _currentTile.GetXPos();
            int yPos = _currentTile.GetYPos();

            if (CheckMineTiles(xPos, yPos, (int)MineProximity.VeryClose))
            {
                _renderer.DrawProximity((int)MineProximity.VeryClose);
            }
            else if(CheckMineTiles(xPos, yPos, (int)MineProximity.Close))
            {
                _renderer.DrawProximity((int)MineProximity.Close);
            }
        }

        private bool CheckMineTiles(int xPos, int yPos, int distance)
        {
            return CheckMineTile(xPos + distance, yPos)
                || CheckMineTile(xPos - distance, yPos)
                || CheckMineTile(xPos, yPos + distance)
                || CheckMineTile(xPos, yPos - distance);
        }

        private bool CheckMineTile(int xPos, int yPos)
        {
            if (xPos >= 0 && xPos < _boardWidth && yPos > 0 && yPos < _boardHeight)
                return _tiles[xPos, yPos] is MineTile;
            return false;
        }

        public enum MineProximity
        {
            VeryClose = 1,
            Close = 2
        }
    }
}
