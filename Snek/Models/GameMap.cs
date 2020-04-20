using System.Collections.Generic;

namespace Snek.Models
{
    /// <summary>
    /// Represents the game map
    /// </summary>
    public class GameMap
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
        public GameMapTile[,] Board { get; }

        /// <summary>
        /// Indexer accepting two integers.
        /// </summary>
        public GameMapTile this[int x, int y] => Board[x, y];

        /// <summary>
        /// Indexer accepting a Point struct.
        /// </summary>
        public GameMapTile this[Point point] => Board[point.X, point.Y];

        /// <summary>
        /// The constructor sets the max size of the game board, and initializes it.
        /// </summary>
        /// <param name="size">The max length of each side of the board</param>
        /// <param name="style">Determines the style of each map tile.</param>
        public GameMap(int size = 10, TileStyle style = TileStyle.SquareBrackets)
        {
            MAX_SIZE = size;
            _style = style;
            Board = new GameMapTile[MAX_SIZE, MAX_SIZE];

            // Initialize the game board
            InitializeBoard(_style);
        }

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

        public void PlaceFood(Point location) => this[location].PlaceFood();


        /// <summary>
        /// Reset the board to its original values.
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

        private void InitializeBoard(TileStyle style)
        {
            for (int y = 0; y < MAX_SIZE; y++)
            {
                for (int x = 0; x < MAX_SIZE; x++)
                {
                    Board[x, y] = new GameMapTile(style);
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