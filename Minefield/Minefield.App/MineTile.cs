using Minefield.App.Interfaces;

namespace Minefield.App
{
    public class MineTile : Tile
    {
        public MineTile(int x, int y, string _xLabel = null, string _yLabel = null) : base(x, y, _xLabel, _yLabel)
        {
        }

        public override void Activate(IPlayer player, IRenderer renderer)
        {

        }
    }
}
