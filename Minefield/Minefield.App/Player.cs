using Minefield.App.Interfaces;

namespace Minefield.App
{
    public class Player : IPlayer
    {
        IBoard _board;
        IRenderer _renderer;
        private int _movesTaken = 0;
        private int _livesRemaining;

        public Player(IBoard board, IRenderer renderer, int lives = 3)
        {
            _board = board;
            _renderer = renderer;
            _livesRemaining = lives;
        }

        public void MoveUp()
        {
            if (_board.ShiftTileUp())
            {
                Move();
            }
        }

        public void MoveDown()
        {
            if (_board.ShiftTileDown())
            {
                Move();
            }
        }

        public void MoveLeft()
        {
            if (_board.ShiftTileLeft())
            {
                Move();
            }
        }

        public void MoveRight()
        {
            if (_board.ShiftTileRight())
            {
                Move();
            }
        }

        private void Move()
        {
            _movesTaken++;
            _renderer.DrawMoves(_movesTaken);
            _renderer.DrawProximity();
            _board.GetActiveTile().Activate(this, _renderer);

            if (!Finished())
                _renderer.DrawLives(_livesRemaining);

            if (_livesRemaining == 0)
                _renderer.DrawGameOver();
        }

        public void ReduceLives(int numOfLives)
        {
            _livesRemaining -= numOfLives;
        }

        public int GetMovesTaken()
        {
            return _movesTaken;
        }

        public bool Alive()
        {
            return _livesRemaining > 0 ? true : false;
        }

        public bool Finished()
        {
            return _board.GetActiveTile() == _board.GetFinishedTile();
        }
    }
}
