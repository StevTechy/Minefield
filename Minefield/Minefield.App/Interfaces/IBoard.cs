namespace Minefield.App
{
    public interface IBoard
    {
        void Setup(int width, int height);
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
