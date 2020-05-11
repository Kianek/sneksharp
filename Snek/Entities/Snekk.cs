using Snek.GameMap;
using Snek.Input;
using System.Linq;
using System.Collections.Generic;

namespace Snek.Entities
{
    /// <summary>
    /// Represents the snek! This class is responsible for managing the snek's
    /// current direction, as well as adding new body segments and updating each segments
    /// location on the map.
    /// </summary>
    public class Snekk
    {
        public Direction Direction { get; set; } = Direction.Right;
        public int Length { get; set; }
        public Segment Head { get; private set; }
        public Segment Tail { get; private set; }
        public Queue<Segment> Body { get; } = new Queue<Segment>();

        public Snekk(Point startingPosition)
        {
            Head = new Segment(startingPosition);

            // Initially, the snek will have two segments
            var tailStartingPosition = startingPosition.Clone();
            tailStartingPosition.X--;
            Tail = new Segment(tailStartingPosition);

            Body.Enqueue(Head);
            Body.Enqueue(Tail);
            Length = Body.Count;
        }


        /// <summary>
        /// This method wraps UpdateLocation, because a new segment will receive the tail
        /// segment's previous value.
        /// </summary>
        /// <param name="location">The new location of the head segment.</param>
        public void AddSegment(Point location)
        {
            var newSegment = new Segment(location);
            // Set Tail to the new segment, and then enqueue it.
            Tail = newSegment;
            Body.Enqueue(Tail);
            Length = Body.Count;
            UpdateLocation(location);
        }

        /// <summary>
        /// Projects the entire body into a list of Points.
        /// </summary>
        /// <returns>A list of points</returns>
        public List<Point> GetSegmentLocations() => Body.Select(segment => segment.Location).ToList();

        /// <summary>
        /// Updates the location of each segment relative to the previous segment.
        /// </summary>
        /// <param name="location"></param>
        public void UpdateLocation(Point location)
        {
            // Hold onto the head's previous location,
            Point previousCoordinates = Head.Location;

            // then update the head's current location
            Head.Location = location;
            foreach (var segment in Body.Skip(1))
            {
                var currentCoordinates = segment.Location;
                // Set the current segment's location to the previous coordinates,
                segment.Location = previousCoordinates;
                // then set previousCoordinates to the (now) current coordinates. 
                previousCoordinates = currentCoordinates;
            }
        }

        /// <summary>
        /// Represents a single segment of the snek's body.
        /// </summary>
        public class Segment
        {
            public Point Location { get; set; }

            public Segment(Point startingPosition)
            {
                Location = startingPosition;
            }

            public Segment Clone() => new Segment(this.Location);
        }
    }
}