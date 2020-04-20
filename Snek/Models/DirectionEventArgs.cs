using System;

namespace Snek.Models
{
    public class DirectionEventArgs : EventArgs
    {
        public Direction Direction { get; }
        public Point PreviousLocation { get; set; }
        public Point NewLocation { get; set; }

        public DirectionEventArgs(Direction direction, Point previousLocation, Point newLocation)
        {
            Direction = direction;
            PreviousLocation = previousLocation;
            NewLocation = newLocation;
        }
    }
}