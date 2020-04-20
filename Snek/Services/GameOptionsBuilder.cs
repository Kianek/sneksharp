using Snek.Models;

namespace Snek.Services
{
    public class GameOptionsBuilder : IGameOptionsBuilder
    {
        private GameOptions options;

        public GameOptionsBuilder()
        {
            InitializeGameOptions();
        }

        public void SetDifficulty(Difficulty difficulty)
        {
            options.Difficulty = difficulty;
        }

        public void SetTileStyle(TileStyle tileStyle) => options.TileStyle = tileStyle;

        public void SetMapSize(MapSize mapSize) => options.MapSize = mapSize;

        public GameOptions Build()
        {
            // Hold onto the current options object.
            GameOptions currentOptionsBuild = options;

            // Reset the object to default values.
            options = null;
            InitializeGameOptions();

            return currentOptionsBuild;
        }

        private void InitializeGameOptions()
        {
            if (options == null)
            {
                options = new GameOptions();
            }
        }
    }
}