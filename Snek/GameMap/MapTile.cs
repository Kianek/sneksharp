namespace Snek.GameMap
{
    /// <summary>
    /// Represents a single tile on the game map.
    /// </summary>
    public class MapTile
    {
        private TileStyle tileStyle;
        public static string Asterisk { get; } = "*";
        public static string BlankSpace { get; } = " ";
        public string Style { get; set; }
        public bool IsOccupied { get; private set; }

        public MapTile(TileStyle style = TileStyle.SquareBrackets)
        {
            tileStyle = style;
            Style = GenerateStyle(tileStyle);
            IsOccupied = false;
        }

        /// <summary>
        /// Swaps the whitespace with an asterisk, or vice versa.
        /// </summary>
        /// <returns>The current occupied status</returns>
        public bool ToggleOccupied()
        {
            if (!IsOccupied)
            {
                Style = Style.Replace(BlankSpace, Asterisk);
            }
            else
            {
                Style = Style.Replace(Asterisk, BlankSpace);
            }
            IsOccupied = !IsOccupied;
            return IsOccupied;
        }

        /// <summary>
        /// Sets the tile's whitespace to the 'o' character, represent food.
        /// </summary>
        public void PlaceFood()
        {
            IsOccupied = true;
            Style = Style.Replace(Asterisk, "o");
        }

        /// <summary>
        /// Resets the tile.
        /// </summary>
        public void Reset()
        {
            Style = GenerateStyle(tileStyle);
            IsOccupied = false;
        }

        public override string ToString() => Style;

        /// <summary>
        /// Sets the tile's style based on the user's choice.
        /// </summary>
        /// <param name="style"></param>
        /// <returns>The string representing the user's chosen style.</returns>
        private string GenerateStyle(TileStyle style)
        {
            switch (style)
            {
                case TileStyle.CurlyBraces: return "{ }";
                case TileStyle.Parentheses: return "( )";
                case TileStyle.SquareBrackets: return "[ ]";
                default: return "[ ]";
            }
        }
    }
}