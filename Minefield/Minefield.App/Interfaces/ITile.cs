namespace Minefield.App.Interfaces
{
    public interface ITile
    {
        void Activate(IPlayer player, IRenderer renderer);
        string GetXLabel();
        string GetYLabel();
        string GetId();
    }
}
