using Minefield.App.Interfaces;
using System;

namespace Minefield.App
{
    public class Engine : IEngine
    {
        public void Start(IBoard board)
        {
            board.Setup(8,8);

            while (true)
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            board.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            board.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            board.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            board.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }
        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
