using Snek.Models;

namespace Snek.Services
{
    /// <summary>
    /// Contains methods to convert the integers 1-3 into their corresponding enum value.
    /// </summary>
    public static class EnumMapper
    {
        public static Difficulty GetDifficulty(int userChoice)
        {
            switch (userChoice)
            {
                case 1: return Difficulty.Easy;
                case 2: return Difficulty.Normal;
                case 3: return Difficulty.Hard;
                default: return Difficulty.Normal;
            }
        }

        public static TileStyle GetTileStyle(int userChoice)
        {
            switch (userChoice)
            {
                case 1: return TileStyle.SquareBrackets;
                case 2: return TileStyle.Parentheses;
                case 3: return TileStyle.CurlyBraces;
                default: return TileStyle.SquareBrackets;
            }
        }

        public static MapSize GetMapSize(int userChoice)
        {
            switch (userChoice)
            {
                case 1: return MapSize.Large;
                case 2: return MapSize.Medium;
                case 3: return MapSize.Small;
                default: return MapSize.Medium;
            }
        }
    }
}