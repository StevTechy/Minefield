namespace Minefield.App.Interfaces
{
    public interface IRenderer
    {
        void Clear();
        void DrawGrid(ITile[,] tiles, ITile currentTile, ITile finishTile);
        void DrawLives(int livesLeft);
        void DrawCurrentPos(ITile currentTile);
        void DrawMoves(int movesTaken);
        void DrawHitByMine();
        void DrawProximity(int distance);
        void DrawGameOver();
        void DrawFinalScore(int score);
        void DrawHeader();
    }
}
