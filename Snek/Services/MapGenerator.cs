using Snek.Models;
using System.Collections.Generic;
using System.Linq;

namespace Snek.Services
{
    /// <summary>
    /// Handles GameMap creation and configuration.
    /// </summary>
    public static class MapGenerator
    {
        /// <summary>
        /// Generates a new GameMap based on the user's specifications.
        /// </summary>
        /// <param name="mapSize"></param>
        /// <param name="tileStyle"></param>
        /// <returns></returns>
        public static GameMap GenerateMap(int mapSize, TileStyle tileStyle) => new GameMap(mapSize, tileStyle);

        /// <summary>
        /// Determines the snek's starting location on the map.
        /// </summary>
        /// <param name="mapSize"></param>
        /// <returns></returns>
        public static Point GenerateStartingPoint(int mapSize) => new Point((mapSize / 2) - 1, (mapSize / 2) - 1);

        /// <summary>
        /// Determine the max height/width of the map.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a List of all of the currently activated GameMapTiles.
        /// </summary>
        /// <param name="snek"></param>
        /// <param name="food"></param>
        /// <returns></returns>
        public static List<Point> GetActiveTiles(Snek snek, Food food)
        {
            var activeTiles = new List<Point>() { food.Location };
            var snakeTiles = snek.Body.Select(segment => segment.Location).ToList();
            activeTiles.AddRange(snakeTiles);

            return activeTiles;
        }
    }
}