using Minefield.App.Interfaces;
using System;

namespace Minefield.App
{
    public class Engine : IEngine
    {
        public void Start(IBoard board, IPlayer player)
        {
            board.Setup(8, 8);

            while (player.Alive() && !player.Finished())
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            player.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            player.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            player.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            player.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            board.Setup(8, 8);
                            player.Reset();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }

            End();
        }

        public void End()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        var renderer = new StandardConsoleWriter();
                        var board = new Chessboard(renderer);
                        Start(board, new Player(board, renderer));
                        break;
                    }
                case ConsoleKey.Escape: { return; }
                default: { End(); break; }
            }
        }
    }
}
