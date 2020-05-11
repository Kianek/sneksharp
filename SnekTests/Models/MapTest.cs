using FluentAssertions;
using Snek.GameMap;
using Xunit;

namespace SnekTests.Models
{
    public class MapTest
    {
        [Fact]
        public void CanGenerateDefaultGameMap()
        {
            // Map grid is 10x10 by default
            var result = new Map();

            int maxSize = result.MAX_SIZE;
            int sizeSquared = maxSize * maxSize;
            result.NumOfTiles.Should().Be(100, $"{maxSize}^2 equals: {sizeSquared}");
        }

        [Fact]
        public void CanGenerateGameMapOfSpecifiedSize()
        {
            // Map grid is 10x10 by default
            var maxSize = 5;
            var sizeSquared = maxSize * maxSize;
            var result = new Map(maxSize);


            result.NumOfTiles.Should().Be(sizeSquared, $"{maxSize}^2 equals: {sizeSquared}");
        }

        [Fact]
        public void CanInstantiateEachMapElement()
        {
            // Create map of 25 tiles
            var maxSize = 5;
            var map = new Map(maxSize);

            for (int x = 0; x < maxSize; x++)
            {
                for (int y = 0; y < maxSize; y++)
                {
                    map.Board[x, y].Should().BeOfType<MapTile>("the constructor should have initialized the game board");
                }
            }
        }

        [Fact]
        public void CanConvertSelfToFormattedString()
        {
            var maxSize = 2;
            var map = new Map(maxSize, TileStyle.SquareBrackets);

            var board = map.ToString();
            var expected = "[ ][ ]\n[ ][ ]\n";
            board.Should().Be(expected);
        }

        [Fact]
        public void CanResetMap()
        {
            var maxSize = 2;
            var map = new Map(maxSize, TileStyle.SquareBrackets);

            // Toggle each map tile.
            for (int x = 0; x < maxSize; x++)
            {
                for (int y = 0; y < maxSize; y++)
                {
                    map[x, y].ToggleOccupied();
                }
            }

            var activatedMap = map.ToString();
            var expected = "[ ][ ]\n[ ][ ]\n";
            map.Reset();

            map.ToString().Should().NotBe(activatedMap, "it has been reset");
            map.ToString().Should().Be(expected, "it has been reset");
        }
    }
}