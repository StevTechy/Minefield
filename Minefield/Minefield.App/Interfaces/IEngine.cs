namespace Minefield.App.Interfaces
{
    public interface IEngine
    {
        void Start(IBoard board, IPlayer player);

        void End();
    }
}
