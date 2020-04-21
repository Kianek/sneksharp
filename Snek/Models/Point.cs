using System;
namespace Snek.Models
{
    /// <summary>
    /// Represents a set of x and y coordinates. 
    /// </summary>
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public Point Clone() => new Point(X, Y);

        public override string ToString() => $"[X: {X}, Y: {Y}]";

        public static bool operator ==(Point one, Point other)
        {
            if (((object)one == null) || ((object)one == null))
            {
                return Object.Equals(one, other);
            }

            return one.Equals(other);
        }

        public static bool operator !=(Point one, Point other)
        {
            if (((object)one == null) || ((object)other == null))
            {
                return Object.Equals(one, other);
            }
            return !(one.Equals(other));
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;

            var other = obj as Point;
            if (other == null) return false;
            return Equals(other);
        }

        public bool Equals(Point other)
        {
            if (other == null) return false;

            return this.X == other.X && this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(X, Y).GetHashCode();
        }
    }
}