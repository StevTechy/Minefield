namespace Minefield.App.Interfaces
{
    public interface ITile
    {
        void Activate(IPlayer player, IRenderer renderer);
        int GetXPos();
        int GetYPos();
        string GetXLabel();
        string GetYLabel();
        string GetId();
    }
}
