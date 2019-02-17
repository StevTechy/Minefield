namespace Minefield.App.Interfaces
{
    public interface IRenderer
    {
        void Clear();
        void DrawGrid(ITile[,] tiles, ITile currentTile);
        void DrawLives(int livesLeft);
        void DrawCurrentPos(ITile currentTile);
        void DrawMoves(int movesTaken);
        void DrawProximity();
        void DrawFinalScore(int score);
        void DrawHeader();
    }
}
