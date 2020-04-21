using FluentAssertions;
using Snek.Models;
using Snek.Services;
using Xunit;

namespace SnekTests.Services
{
    public class GameOptionsBuilderTest
    {
        [Fact]
        public void CanBuildDefaultGameOptions()
        {
            var optionsBuilder = new GameOptionsBuilder();
            var result = optionsBuilder.Build();

            result.Should().BeOfType<GameOptions>();
            result.Should().NotBeNull("because it is initialized automatically during builder construction");
        }

        [Fact]
        public void CanSetDifficulty()
        {
            var optionsBuilder = new GameOptionsBuilder();
            optionsBuilder.SetDifficulty(Difficulty.Hard);
            var result = optionsBuilder.Build();

            result.Difficulty.Should().Be(Difficulty.Hard);
        }

        [Fact]
        public void CanSetMapSize()
        {
            var optionsBuilder = new GameOptionsBuilder();
            optionsBuilder.SetMapSize(MapSize.Large);
            var result = optionsBuilder.Build();

            result.MapSize.Should().Be(MapSize.Large);
        }

        [Fact]
        public void CanSetTileStyle()
        {
            var optionsBuilder = new GameOptionsBuilder();
            optionsBuilder.SetTileStyle(TileStyle.Parentheses);
            var result = optionsBuilder.Build();

            result.TileStyle.Should().Be(TileStyle.Parentheses);
        }

        [Fact]
        public void CanBuildGameOptionsWithNonDefaultValues()
        {
            var difficulty = Difficulty.Easy;
            var mapSize = MapSize.Large;
            var tileStyle = TileStyle.SquareBrackets;
            var optionsBuilder = new GameOptionsBuilder();

            optionsBuilder.SetDifficulty(difficulty);
            optionsBuilder.SetMapSize(mapSize);
            optionsBuilder.SetTileStyle(tileStyle);
            var result = optionsBuilder.Build();

            result.Difficulty.Should().Be(difficulty);
            result.MapSize.Should().Be(mapSize);
            result.TileStyle.Should().Be(tileStyle);
        }

        [Fact]
        public void CanResetInternalGameOptionsAfterBuild()
        {
            var optionsBuilder = new GameOptionsBuilder();
            optionsBuilder.SetDifficulty(Difficulty.Easy);
            optionsBuilder.SetMapSize(MapSize.Large);
            optionsBuilder.SetTileStyle(TileStyle.SquareBrackets);
            var result = optionsBuilder.Build();
            var defaultBuild = optionsBuilder.Build();

            result.Should().NotBeEquivalentTo(defaultBuild);
        }
    }
}