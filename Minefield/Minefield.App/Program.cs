namespace Minefield.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var renderer = new StandardConsoleWriter();
            var board = new Chessboard(renderer);
            new Engine().Start(board, new Player(board, renderer));
        }
    }
}
