using Minefield.App;
using Minefield.Tests.MockObjects;
using Xunit;

namespace Minefield.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Move()
        {
            var player = new Player(new MockBoard(), new MockRenderer(), 3);

            player.MoveDown();

            Assert.Equal(1, player.GetMovesTaken());
        }

        [Fact]
        public void ReduceLives()
        {
            int startingLives = 3, livesToDecrement = 1;

            var player = new Player(new MockBoard(), new MockRenderer(), startingLives);

            player.ReduceLives(livesToDecrement);

            Assert.Equal(startingLives - livesToDecrement, player.GetLivesLeft());
        }

        [Fact]
        public void CheckIfAlive()
        {
            int startingLives = 3;

            var player = new Player(new MockBoard(), new MockRenderer(), startingLives);

            player.ReduceLives(1);

            Assert.True(player.Alive());

            player.ReduceLives(startingLives - 1);

            Assert.False(player.Alive());
        }
    }
}
