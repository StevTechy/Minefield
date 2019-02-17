using Minefield.App.Interfaces;

namespace Minefield.App
{
    public class Tile : ITile
    {
        private string _id;
        private string _xLabel;
        private string _yLabel;

        public Tile(int x, int y, string xLabel = null, string yLabel = null)
        {
            XPos = x;
            YPos = y;

            if (xLabel != null)
                _xLabel = xLabel;
            else _xLabel = x.ToString();

            if (yLabel != null)
                _yLabel = yLabel;
            //Need to set this to + 1 here as the console needs to print starting from 1 not 0
            else _yLabel = (y + 1).ToString();

            _id = _xLabel + _yLabel;
        }

        public string Id { get; }
        public int XPos { get; }
        public int YPos { get; }
        public string GetXLabel() { return _xLabel; }
        public string GetYLabel() { return _yLabel; }
        public string GetId() { return _id; }

        public virtual void Activate(IPlayer player, IRenderer renderer)
        {

        }
    }

}
