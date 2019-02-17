using Minefield.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minefield.Tests.MockObjects
{
    public class MockRenderer : IRenderer
    {
        public void Clear()
        {
        }

        public void DrawCurrentPos(ITile currentTile)
        {
        }

        public void DrawFinalScore(int score)
        {
        }

        public void DrawGameOver()
        {
        }

        public void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile)
        {
        }

        public void DrawHeader()
        {
        }

        public void DrawHitByMine()
        {
        }

        public void DrawLives(int livesLeft)
        {
        }

        public void DrawMoves(int movesTaken)
        {
        }

        public void DrawProximity(int distance)
        {
        }
    }
}
