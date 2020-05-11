using Snek.GameMap;
using System.Linq;
using System.Collections.Generic;

namespace Snek.Services
{
    /// <summary>
    /// Provides methods for bounds checking.
    /// </summary>
    public class CollisionDetector
    {
        private int lowerBound = 0;
        private int upperBound;

        /// <summary>
        /// The upper bound is determined by the user's chosen map size.
        /// </summary>
        /// <param name="upperBound"></param>
        public CollisionDetector(int upperBound)
        {
            this.upperBound = upperBound;
        }

        /// <summary>
        /// Checks for equality between two points.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool IsPointCollision(Point a, Point b) => a == b;

        /// <summary>
        /// Checks whether a given point exists in a sequence.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool IsCollisionInSequence(IEnumerable<Point> sequence, Point location)
        {
            return sequence.Any(point => IsPointCollision(point, location));
        }

        /// <summary>
        /// Checks whether the given point is within the range specified by the
        /// lower and upper bounds.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool PointIsOutOfBounds(Point point)
        {
            var xIsOutOfBounds = point.X < lowerBound || upperBound <= point.X;
            var yIsOutOfBounds = point.Y < lowerBound || upperBound <= point.Y;

            return xIsOutOfBounds || yIsOutOfBounds;
        }
    }
}