using System;
namespace Snek.Models
{
    public struct Food
    {
        public string Item { get; }
        public Point Location { get; set; }

        public Food(Point location)
        {
            Item = "o";
            Location = location;
        }

    }
}