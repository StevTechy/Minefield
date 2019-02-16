using Minefield.App.Interfaces;
using System;

namespace Minefield.App
{
    public class Engine : IEngine
    {
        public void Start(IBoard board)
        {
            board.Setup(8, 8);

            while (true)
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            board.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            board.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            board.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            board.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
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
