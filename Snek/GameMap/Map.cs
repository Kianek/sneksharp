using System.Collections.Generic;

namespace Snek.GameMap
{
    /// <summary>
    /// Represents the game map.
    /// </summary>
    public class Map
    {
        private TileStyle _style;
        public int MIN_SIZE { get; } = 0;
        public int MAX_SIZE { get; }
        public int NumOfTiles
        {
            get => MAX_SIZE * MAX_SIZE;
        }

        /// <summary>
        /// The game board.
        /// </summary>
        /// <value>
        /// A uniform multidimensional array representing the game board.
        /// </value>
        public MapTile[,] Board { get; }

        /// <summary>
        /// Indexer accepting two integers.
        /// </summary>
        public MapTile this[int x, int y] => Board[x, y];

        /// <summary>
        /// Indexer accepting a Point struct.
        /// </summary>
        public MapTile this[Point point] => Board[point.X, point.Y];

        /// <summary>
        /// The constructor sets the max size of the game board, and initializes it.
        /// </summary>
        /// <param name="size">The max length of each side of the board</param>
        /// <param name="style">Determines the style of each map tile.</param>
        public Map(int size = 10, TileStyle style = TileStyle.SquareBrackets)
        {
            MAX_SIZE = size;
            _style = style;
            Board = new MapTile[MAX_SIZE, MAX_SIZE];

            // Initialize the game board
            InitializeBoard(_style);
        }

        /// <summary>
        /// Resets the map, and then updates it with the currently activated tiles.
        /// </summary>
        /// <param name="activeTiles">An IEnumerable representing the currently active tiles</param>
        public void ActivateTiles(IEnumerable<Point> activeTiles)
        {
            this.Reset();
            foreach (var point in activeTiles)
            {
                var tile = this[point];
                if (!tile.IsOccupied)
                {
                    tile.ToggleOccupied();
                }
            }
        }

        /// <summary>
        /// Places food at a specific point on the map.
        /// </summary>
        /// <param name="location">The point on the map to place food.</param>
        public void PlaceFood(Point location) => this[location].PlaceFood();


        /// <summary>
        /// Resets the board to its original values.
        /// </summary>
        public void Reset()
        {
            for (int y = 0; y < MAX_SIZE; y++)
            {
                for (int x = 0; x < MAX_SIZE; x++)
                {
                    Board[x, y].Reset();
                }
            }
        }

        /// <summary>
        /// Initializes the map tiles with the given style.
        /// </summary>
        /// <param name="style">The style with which to initialize each tile.</param>
        private void InitializeBoard(TileStyle style)
        {
            for (int y = 0; y < MAX_SIZE; y++)
            {
                for (int x = 0; x < MAX_SIZE; x++)
                {
                    Board[x, y] = new MapTile(style);
                }
            }
        }

        /// <summary>
        /// Converts the map to a formatted string.
        /// </summary>
        /// <returns>A prettified string representation of the game board</returns>
        public override string ToString()
        {
            var result = "";
            for (int y = 0; y < MAX_SIZE; y++)
            {
                for (int x = 0; x < MAX_SIZE; x++)
                {
                    result += Board[x, y];
                }
                result += "\n";
            }
            return result;
        }
    }
}