using Snek.GameMap;

namespace Snek.GameEngine
{
    public interface IGameOptionsBuilder
    {
        void SetDifficulty(Difficulty difficulty);
        void SetTileStyle(TileStyle tileStyle);
        void SetMapSize(MapSize mapSize);
        GameOptions Build();
    }
}