using Minefield.App;
using Minefield.Tests.MockObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minefield.Tests
{
    public class ChessboardTests
    {
        /// <summary>
        /// Check active and finish tile have correct type and valid position
        /// </summary>
        [Fact]
        public void Setup()
        {
            int boardWidth = 8, boardHeight = 8;
            var board = new Chessboard(new MockRenderer());
            board.Setup(boardWidth, boardHeight);
            var activeTile = board.GetActiveTile();
            var finishTile = board.GetFinishedTile();

            Assert.Equal(typeof(Tile), activeTile.GetType());
            Assert.Equal(0, activeTile.GetYPos());
            Assert.True(activeTile.GetXPos() >= 0 && activeTile.GetXPos() < boardWidth);

            Assert.Equal(typeof(FinishTile), finishTile.GetType());
            Assert.Equal(boardHeight - 1, finishTile.GetYPos());
            Assert.True(finishTile.GetXPos() >= 0 && finishTile.GetXPos() < boardWidth);
        }

        /// <summary>
        /// Check correct number of tiles were generated with correct Ids
        /// </summary>
        [Fact]
        public void GenerateTiles()
        {
            var tiles = new Chessboard(new MockRenderer()).GenerateTiles(8, 8);

            Assert.Equal("A1", tiles[0, 0].GetId());
            Assert.Equal("H8", tiles[7, 7].GetId());
            Assert.Equal(8, tiles.GetLength(0));
            Assert.Equal(8, tiles.GetLength(1));
        }

        /// <summary>
        /// Check tile with correct Id and Type is generated
        /// </summary>
        [Fact]
        public void GenerateFinishTile()
        {
            var boardHeight = 8;
            var tile = new Chessboard(new MockRenderer()).GenerateFinishTile(2, boardHeight);

            Assert.Equal(typeof(FinishTile), tile.GetType());
            Assert.Equal("C8", tile.GetId());
        }

        /// <summary>
        /// Check current tile gets changed correctly for each direction
        /// </summary>
        [Fact]
        public void ShiftTile()
        {
            int boardWidth = 2, boardHeight = 2;

            var board = new Chessboard(new MockRenderer());

            board.Setup(boardWidth, boardHeight);

            board.SetActiveTile(0, 0);
            Assert.True(board.GetActiveTile().GetId() == "A1");

            board.ShiftTileRight();
            Assert.True(board.GetActiveTile().GetId() == "B1");

            board.ShiftTileUp();
            Assert.True(board.GetActiveTile().GetId() == "B2");

            board.ShiftTileLeft();
            Assert.True(board.GetActiveTile().GetId() == "A2");

            board.ShiftTileDown();
            Assert.True(board.GetActiveTile().GetId() == "A1");
        }
    }
}
