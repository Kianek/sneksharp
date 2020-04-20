using System;
using Snek.Models;

namespace Snek.Services
{
    public class DirectionMapper
    {
        /// <summary>
        /// Maps console arrow key input to a Direction enum value.
        /// </summary>
        /// <param name="keyInfo"></param>
        /// <returns>A Direction value</returns>
        public Direction GetDirectionFromKey(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: return Direction.Up;
                case ConsoleKey.RightArrow: return Direction.Right;
                case ConsoleKey.DownArrow: return Direction.Down;
                case ConsoleKey.LeftArrow: return Direction.Left;
                default: return Direction.Right;
            }
        }

        /// <summary>
        /// Clones an existing Point, and then adjusts the clone's coordinates
        /// relative to the given ConsoleKeyInfo value. If the altered value of the cloned point
        /// is within bounds, the modified clone
        /// </summary>
        /// <param name="previousLocation"></param>
        /// <param name="keyInfo"></param>
        /// <returns>If the altered value is within bounds, returns the updated clone; otherwise, return the unmodified copy</returns>
        // public Point CalculateNewPosition(Point previousLocation, ConsoleKeyInfo keyInfo)
        public Point CalculateNewPosition(Point previousLocation, Direction direction)
        {
            var point = previousLocation.Clone();
            switch (direction)
            {
                case Direction.Up:
                    point.Y -= 1;
                    break;
                case Direction.Left:
                    point.X -= 1;
                    break;
                case Direction.Right:
                    point.X += 1;
                    break;
                case Direction.Down:
                    point.Y += 1;
                    break;
                default: return point;
            }

            return point;
        }
    }
}