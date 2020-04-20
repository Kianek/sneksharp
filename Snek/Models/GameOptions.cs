namespace Snek.Models
{
    public class GameOptions
    {
        public TileStyle TileStyle { get; set; }
        public Difficulty Difficulty { get; set; }
        public MapSize MapSize { get; set; }

        public GameOptions(
            TileStyle tileStyle = TileStyle.SquareBrackets,
            Difficulty difficulty = Difficulty.Normal,
            MapSize mapSize = MapSize.Medium)
        {
            TileStyle = tileStyle;
            Difficulty = difficulty;
            MapSize = mapSize;
        }
    }
}