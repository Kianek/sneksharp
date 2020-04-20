using System.Runtime.CompilerServices;
namespace Snek.Models
{
    public class GameMapTile
    {
        private TileStyle tileStyle;
        public static string Asterisk { get; } = "*";
        public static string BlankSpace { get; } = " ";
        public string Style { get; set; }
        public bool IsOccupied { get; private set; }

        public GameMapTile(TileStyle style = TileStyle.SquareBrackets)
        {
            tileStyle = style;
            Style = GenerateStyle(tileStyle);
            IsOccupied = false;
        }

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

        public void PlaceFood()
        {
            ToggleOccupied();
            Style = Style.Replace(" ", "o");
        }

        public void Reset()
        {
            Style = GenerateStyle(tileStyle);
            IsOccupied = false;
        }

        public override string ToString() => Style;

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