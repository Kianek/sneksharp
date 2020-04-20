using Snek.Models;
using System.Collections.Generic;
using System.Linq;

namespace Snek.Services
{
    public static class MapGenerator
    {
        public static GameMap GenerateMap(int mapSize, TileStyle tileStyle) => new GameMap(mapSize, tileStyle);

        public static Point GenerateStartingPoint(int mapSize) => new Point((mapSize / 2) - 1, (mapSize / 2) - 1);

        public static int SetMapSize(MapSize size)
        {
            switch (size)
            {
                case (MapSize.Small): return 10;
                case (MapSize.Medium): return 12;
                case (MapSize.Large): return 15;
                default: return 10;
            }
        }

        public static List<Point> GetActiveTiles(Snek snek, Food food)
        {
            var activeTiles = new List<Point>() { food.Location };
            var snakeTiles = snek.Body.Select(segment => segment.Location).ToList();
            activeTiles.AddRange(snakeTiles);

            return activeTiles;
        }
    }
}