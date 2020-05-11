using FluentAssertions;
using Snek.GameMap;
using Xunit;

namespace SnekTests
{
    public class MapTileTest
    {
        private string[] unoccupiedTiles;
        private string[] occupiedTiles;
        private TileStyle[] styles;

        public MapTileTest()
        {
            unoccupiedTiles = new string[] { "{ }", "( )", "[ ]" };
            occupiedTiles = new string[] { "{*}", "(*)", "[*]" };
            styles = new TileStyle[]
            {
                TileStyle.CurlyBraces,
                TileStyle.Parentheses,
                TileStyle.SquareBrackets
            };
        }

        [Fact]
        public void CanGenerateStyleFromValidTileOptions()
        {
            // Iterate over the unoccuped tiles to test that
            // new map tiles are being instantiated properly.
            for (int i = 0; i < styles.Length; i++)
            {
                Test(unoccupiedTiles[i], styles[i]);
            }

            void Test(string expr, TileStyle style = TileStyle.SquareBrackets)
            {
                var result = new MapTile(style);
                result.Style.Should().Be(expr);
            }
        }

        [Fact]
        public void ToggleOccupied_AddSymbol()
        {
            MapTile tile;

            for (int i = 0; i < styles.Length; i++)
            {
                tile = GenerateTile(styles[i]);

                tile.ToggleOccupied();
                tile.Style.Should().Contain("*", "the tile is occupied");
            }

            MapTile GenerateTile(TileStyle style)
            {
                return new MapTile(style);
            }
        }

        [Fact]
        public void ToggleOccupied_RemoveSymbol()
        {
            MapTile tile;

            for (int i = 0; i < styles.Length; i++)
            {
                // This tile has already been occupied, so...
                tile = GenerateOccupiedTile(styles[i]);

                // ...now the tile should remove the symbol
                tile.ToggleOccupied();
                tile.Style.Should().NotContain("*", "the tile is not occupied");
            }

            MapTile GenerateOccupiedTile(TileStyle style)
            {
                var result = new MapTile(style);
                result.ToggleOccupied();
                return result;
            }
        }
    }
}
