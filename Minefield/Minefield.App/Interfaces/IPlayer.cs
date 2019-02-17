namespace Minefield.App.Interfaces
{
    public interface IPlayer
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void ReduceLives(int numOfLives);
        int GetMovesTaken();
        bool Alive();
        bool Finished();
    }
}
