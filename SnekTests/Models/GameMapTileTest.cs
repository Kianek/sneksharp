using FluentAssertions;
using Snek.Models;
using System.Collections.Generic;
using Xunit;

namespace SnekTests
{
    public class GameMapTileTest
    {
        private string[] unoccupiedTiles;
        private string[] occupiedTiles;
        private TileStyle[] styles;

        public GameMapTileTest()
        {
            unoccupiedTiles = new string[] { " ", "{ }", "( )", "[ ]" };
            occupiedTiles = new string[] { "*", "{*}", "(*)", "[*]" };
            styles = new TileStyle[]
            {
                TileStyle.None,
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

            void Test(string expr, TileStyle style = TileStyle.None)
            {
                var result = new GameMapTile(style);
                result.Style.Should().Be(expr);
            }
        }

        [Fact]
        public void ToggleOccupied_AddSymbol()
        {
            GameMapTile tile;

            for (int i = 0; i < styles.Length; i++)
            {
                tile = GenerateTile(styles[i]);

                tile.ToggleOccupied();
                tile.Style.Should().Contain("*", "the tile is occupied");
            }

            GameMapTile GenerateTile(TileStyle style)
            {
                return new GameMapTile(style);
            }
        }

        [Fact]
        public void ToggleOccupied_RemoveSymbol()
        {
            GameMapTile tile;

            for (int i = 0; i < styles.Length; i++)
            {
                // This tile has already been occupied, so...
                tile = GenerateOccupiedTile(styles[i]);

                // ...now the tile should remove the symbol
                tile.ToggleOccupied();
                tile.Style.Should().NotContain("*", "the tile is not occupied");
            }

            GameMapTile GenerateOccupiedTile(TileStyle style)
            {
                var result = new GameMapTile(style);
                result.ToggleOccupied();
                return result;
            }
        }
    }
}
