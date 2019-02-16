namespace Minefield.App
{
    public class Tile
    {
        public Tile(int x, int y, string _xLabel = null, string _yLabel = null)
        {
            XPos = x;
            YPos = y;

            if (_xLabel != null)
                XLabel = _xLabel;
            else XLabel = x.ToString();

            if (_yLabel != null)
                YLabel = _yLabel;
            else YLabel = y.ToString();

            Id = XLabel + YLabel;
        }

        public string Id { get; }
        public int XPos { get; }
        public int YPos { get; }
        public string XLabel { get; }
        public string YLabel { get; }

        public bool IsActive { get; set; }

        public enum State
        {
            Current,
            Goal,
            Mine
        }
    }

}
