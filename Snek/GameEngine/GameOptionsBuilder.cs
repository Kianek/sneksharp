using Snek.GameMap;

namespace Snek.GameEngine
{
    /// <summary>
    /// Provides facilities to build a GameOptions object.
    /// </summary>
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

        /// <summary>
        /// Returns the current configured GameOptions object, and re-initializes the GameOptions
        /// </summary>
        /// <returns>A configured GameOptions object</returns>
        public GameOptions Build()
        {
            // Hold onto the current options object.
            GameOptions currentOptionsBuild = options;

            // Reset the object to default values.
            options = null;
            InitializeGameOptions();

            return currentOptionsBuild;
        }

        /// <summary>
        /// Instantiates a new GameOptions object.
        /// </summary>
        private void InitializeGameOptions()
        {
            if (options == null)
            {
                options = new GameOptions();
            }
        }
    }
}