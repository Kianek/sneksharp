using Snek.Models;

namespace Snek.Services
{
    public interface IGameOptionsBuilder
    {
        void SetDifficulty(Difficulty difficulty);
        void SetTileStyle(TileStyle tileStyle);
        void SetMapSize(MapSize mapSize);
        GameOptions Build();
    }
}