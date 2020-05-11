using Snek.GameMap;

namespace Snek.Entities
{
    /// <summary>
    /// Represents a food item, and stores its location on the map.
    /// </summary>  
    public struct Food
    {
        public Point Location { get; set; }

        public Food(Point location)
        {
            Location = location;
        }

    }
}