using Minefield.App.Interfaces;

namespace Minefield.App
{
    public class FinishTile : Tile
    {
        public FinishTile(int x, int y, string xLabel = null, string yLabel = null) : base(x, y, xLabel, yLabel)
        {
        }

        public override void Activate(IPlayer player, IRenderer renderer)
        {
            renderer.DrawFinalScore(player.GetMovesTaken());
        }
    }
}
