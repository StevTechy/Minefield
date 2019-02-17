using Minefield.App.Interfaces;
using System;

namespace Minefield.App
{
    public class StandardConsoleWriter : IRenderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DrawHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" Welcome to Minefield! Reach the end while avoiding the mines");
            Console.WriteLine(" Press Enter to restart, or Escape to exit");
        }

        public void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile)
        {
            Console.CursorVisible = false;

            var width = tiles.GetLength(0);
            var height = tiles.GetLength(1) - 1;

            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write(" ");
                Console.Write(tiles[0, y].GetYLabel());
                Console.Write(" ");
                for (var x = 0; x < width; x++)
                {
                    if (tiles[x, y] == currentTile)
                        Console.Write("[x]");
                    else if (tiles[x, y] == finishTile)
                        Console.Write("[o]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }

            Console.Write("    ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(tiles[x, 0].GetXLabel());
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawLives(int livesLeft)
        {
            Console.WriteLine($" Lives left: {livesLeft}");
        }

        public void DrawHitByMine()
        {
            Console.WriteLine(" ****You've been hit by a mine!****");
        }

        public void DrawCurrentPos(ITile currentTile)
        {
            Console.WriteLine($" Current position: {currentTile.GetId()}");
        }

        public void DrawMoves(int movesTaken)
        {
            Console.WriteLine($" Moves taken: {movesTaken}");
        }

        public void DrawProximity(int distance)
        {
            switch (distance)
            {
                case 1:
                    {
                        Console.WriteLine(" You are very close to a mine");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" You are close to a mine");
                        break;
                    }
            }
        }

        public void DrawFinalScore(int score)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ***WELL DONE!***");
            Console.WriteLine(" You reached the end with lives left");
            Console.WriteLine($" Final Score: {score}");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
        }

        public void DrawGameOver()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ***GAME OVER!***");
            Console.WriteLine(" You have ran out of lives!");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
        }
    }
}
