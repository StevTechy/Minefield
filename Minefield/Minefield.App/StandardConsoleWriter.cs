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

        public void DrawGrid(Tile[,] tiles, Tile currentTile)
        {
            Console.CursorVisible = false;

            var width = tiles.GetLength(0);
            var height = tiles.GetLength(1) - 1;

            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write(" ");
                Console.Write(tiles[0, y].YLabel);
                Console.Write(" ");
                for (var x = 0; x < width; x++)
                {
                    Console.Write(tiles[x, y].Id == currentTile.Id ? "[x]" : "[ ]");
                }
                Console.WriteLine();
            }
            

            Console.Write("    ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(tiles[x, 0].XLabel);
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawLives(int livesLeft)
        {
            Console.WriteLine($" Lives left: {livesLeft}");
        }

        public void DrawCurrentPos(Tile currentTile)
        { 
            Console.WriteLine($" Current position: {currentTile.Id}");
        }

        public void DrawMoves(int movesTaken)
        {
            Console.WriteLine($" Moves taken: {movesTaken}");
        }

        public void DrawProximity()
        {
            Console.WriteLine($" Proximity to mine: N/A");
        }

        public void DrawFinalScore(int score)
        {
            Console.WriteLine($" Final Score: {score}");
        }

        public void DrawHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" Welcome to Minefield! Reach the end while avoiding the mines");
            Console.WriteLine(" Press Enter to exit");
        }
    }
}
