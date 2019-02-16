using System;

namespace Minefield.App
{
    class Program
    {
        static void Main(string[] args)
        {
            new Engine().Start(new Chessboard(new StandardConsoleWriter()));
        }
    }
}
