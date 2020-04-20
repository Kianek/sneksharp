using System.Linq;
using Snek.Models;
using System.Collections.Generic;

namespace Snek.Services
{
    public class CollisionDetector
    {
        private int lowerBound = 0;
        private int upperBound;

        public CollisionDetector(int upperBound)
        {
            this.upperBound = upperBound;
        }

        public bool IsPointCollision(Point a, Point b) => a == b;

        public bool IsCollisionInSequence(IEnumerable<Point> sequence, Point location)
        {
            return sequence.Any(point => IsPointCollision(point, location));
        }

        public bool PointIsOutOfBounds(Point point)
        {
            var xIsOutOfBounds = point.X < lowerBound || upperBound <= point.X;
            var yIsOutOfBounds = point.Y < lowerBound || upperBound <= point.Y;

            return xIsOutOfBounds || yIsOutOfBounds;
        }
    }
}