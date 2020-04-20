using Snek.Models;
using System;

namespace Snek.Services
{
    public class RandomPointGenerator : IRandomPointGenerator
    {
        private readonly int MAX_SIZE;
        private readonly Random random;
        public RandomPointGenerator(int maxSize)
        {
            MAX_SIZE = maxSize;
            random = new Random();
        }

        public Point NextPoint() => GeneratePoint();

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

        public static RandomPointGenerator Create(int maxSize) => new RandomPointGenerator(maxSize);

        private Point GeneratePoint()
        {
            var x = random.Next(0, MAX_SIZE);
            var y = random.Next(0, MAX_SIZE);

            return new Point(x, y);
        }
    }
}