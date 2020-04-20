using System.Linq;
using Snek.Models;
using System.Collections.Generic;

namespace Snek
{
    public class Snek
    {
        public Direction Direction { get; set; } = Direction.Right;
        public int Length { get; set; }
        public Segment Head { get; private set; }
        public Segment Tail { get; private set; }
        public Queue<Segment> Body { get; } = new Queue<Segment>();

        public Snek(Point startingPosition)
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


        // This method wraps UpdateLocation, because a new segment will receive the tail
        // segment's previous value.
        public void AddSegment(Point location)
        {
            var newSegment = new Segment(location);
            // Set Tail to the new segment, and then enqueue it.
            Tail = newSegment;
            Body.Enqueue(Tail);
            Length = Body.Count;
            UpdateLocation(location);
        }

        public List<Point> GetSegmentLocations() => Body.Select(segment => segment.Location).ToList();

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