using Snek.GameMap;
using System;

namespace Snek.Input
{
    /// <summary>
    /// Extends the EventArgs class, and contains information relevant to the user's
    /// direction input. This event is raised by the DirectionMapper.
    /// </summary>
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