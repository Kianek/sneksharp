using System.Timers;
using Snek.Models;
using Snek.Services;
using System;

namespace Snek
{
    /// <summary>
    /// The Engine class is responsible for coordinating all of the operations
    /// between the game's models and services.
    /// </summary>
    public class Engine
    {
        private ScoreBoard scoreBoard;
        private Snek snek;
        private Food food;
        private GameMap map;
        private RoundStatus roundStatus;
        private int mapSize;

        private IRandomPointGenerator randomPointGenerator;
        private FoodGenerator foodGenerator;
        private RoundTimer timer;
        private CollisionDetector colDetector;
        private DirectionMapper directionMapper;
        private DirectionInputListener inputListener;

        public Engine()
        {
            scoreBoard = new ScoreBoard();
            directionMapper = new DirectionMapper();
            roundStatus = new RoundStatus();

            // Hook up the input listener and set the event handler.
            inputListener = new DirectionInputListener(directionMapper);
            inputListener.OnKeyPress += (source, e) => snek.Direction = e.Direction;
        }

        /// <summary>
        /// Handles the initialization of game-specific options.
        /// </summary>
        /// <param name="options">Contains the user's desired game options</param>
        public void Initialize(GameOptions options)
        {
            // Get the map size that will be used for the current game.
            mapSize = MapGenerator.SetMapSize(options.MapSize);

            // Configure the round timer and hook up the event handler.
            timer = new RoundTimer(options.Difficulty);
            timer.OnTick += (source, e) => ExecuteCycle();

            // Set up collision detection.
            colDetector = new CollisionDetector(mapSize);

            // Initialize the random point and food generators.
            randomPointGenerator = RandomPointGenerator.Create(mapSize);
            foodGenerator = new FoodGenerator(randomPointGenerator);

            // Initialize the game map.
            map = MapGenerator.GenerateMap(mapSize, options.TileStyle);

            // Place the snek and food at their initial locations.
            snek = new Snek(MapGenerator.GenerateStartingPoint(mapSize));
            food = foodGenerator.Generate(snek.GetSegmentLocations());
        }

        /// <summary>
        /// Calls the Initialize method, and starts the game loop.
        /// </summary>
        /// <param name="options">The user-specified game options</param>
        public void Run(GameOptions options)
        {
            Initialize(options);
            timer.Run();

            while (!roundStatus.GameOver)
            {
                inputListener.Listen();
            }

            var points = scoreBoard.Score;
            Console.WriteLine($"Game Over! You scored {points} point{(points == 1 ? "" : "s")}");
            Console.Write("Press Enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Renders the game map and invokes MoveSnek, which updates all the data 
        /// necessary for the next map refresh.
        /// </summary>
        private void ExecuteCycle()
        {
            RenderMap();

            MoveSnek();
        }

        /// <summary>
        /// Updates the game map with the locations of the snek and its food, as well
        /// as the user's current score.
        /// </summary>
        private void RenderMap()
        {
            map.ActivateTiles(MapGenerator.GetActiveTiles(snek, food));
            map.PlaceFood(food.Location);
            Console.WriteLine($"Score: {scoreBoard.Score}");
            Console.WriteLine(map);
        }

        /// <summary>
        /// Calculates the the snek's next location, checks for any boundary collisions,
        /// and checks whether the snek has eaten any food this cycle.
        /// </summary>
        private void MoveSnek()
        {
            Point previousLocation, newSnakeLocation;
            previousLocation = snek.Head.Location;
            newSnakeLocation = directionMapper.CalculateNewPosition(previousLocation, snek.Direction);

            if (MovementIsOutOfBounds(newSnakeLocation))
            {
                EndGame();
                return;
            }

            // Movement is safe, so update the snek's location.
            snek.UpdateLocation(newSnakeLocation);

            // If the new location has food, add to score and generate random location for new food
            var foodIsEaten = newSnakeLocation == food.Location;
            if (foodIsEaten)
            {
                timer.DecreaseInterval();
                snek.AddSegment(food.Location);
                food = foodGenerator.Generate(snek.GetSegmentLocations());
                map.PlaceFood(food.Location);
                scoreBoard.AddPoint();
            }
        }

        /// <summary>
        /// A helper method to prettify bounds checking.
        /// </summary>
        /// <param name="newLocation">The potential new location of the snek's head</param>
        /// <returns></returns>
        private bool MovementIsOutOfBounds(Point newLocation)
        {
            return colDetector.PointIsOutOfBounds(newLocation) ||
                colDetector.IsCollisionInSequence(snek.GetSegmentLocations(), newLocation);
        }

        /// <summary>
        /// A helper method to end the game and stop the round timer and direction input listener.
        /// </summary>
        private void EndGame()
        {
            roundStatus.GameOver = true;
            timer.Stop();
            inputListener.Stop();
        }
    }
}