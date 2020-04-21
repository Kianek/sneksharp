using Snek.Models;
using System;

namespace Snek.Services
{
    /// <summary>
    /// This class is responsible for generating random Points within the bounds of
    /// zero and the user-specified map size.
    /// </summary>
    public class RandomPointGenerator : IRandomPointGenerator
    {
        private readonly int MAX_SIZE;
        private readonly Random random;
        public RandomPointGenerator(int maxSize)
        {
            MAX_SIZE = maxSize;
            random = new Random();
        }

        /// <summary>
        /// Generates a random Point.
        /// </summary>
        /// <returns></returns>
        public Point NextPoint() => GeneratePoint();

        /// <summary>
        /// Generates a random Point. If the generated Point is equal to the Point to exclude,
        /// the method continues generating Points until a non-match is found.
        /// </summary>
        /// <param name="exclude"></param>
        /// <returns></returns>
        public Point NextPoint(Point exclude)
        {
            if (exclude == null)
            {
                return GeneratePoint();
            }

            var point = GeneratePoint();
            while (point == exclude)
            {
                // Generate a new point until you get one that is different from the excluded arg.
                point = GeneratePoint();
            }
            return point;
        }

        /// <summary>
        /// A factory method that instantiates a new RandomPointGenerator with a specific
        /// maximum map size.
        /// </summary>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static RandomPointGenerator Create(int maxSize) => new RandomPointGenerator(maxSize);

        /// <summary>
        /// Generates a single Point with random x and y values.
        /// </summary>
        /// <returns></returns>
        private Point GeneratePoint()
        {
            var x = random.Next(0, MAX_SIZE);
            var y = random.Next(0, MAX_SIZE);

            return new Point(x, y);
        }
    }
}