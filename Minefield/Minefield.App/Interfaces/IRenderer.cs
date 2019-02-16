namespace Minefield.App.Interfaces
{
    public interface IRenderer
    {
        void Clear();
        void DrawGrid(Tile[,] tiles, Tile currentTile);
        void DrawLives(int livesLeft);
        void DrawCurrentPos(Tile currentTile);
        void DrawMoves(int movesTaken);
        void DrawProximity();
        void DrawFinalScore(int score);
        void DrawHeader();
    }
}
