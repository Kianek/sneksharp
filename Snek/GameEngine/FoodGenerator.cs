using Snek.GameMap;
using Snek.Entities;
using System.Collections.Generic;

namespace Snek.GameEngine
{
    /// <summary>
    /// Generates a new location at which to place Food.
    /// </summary>
    public class FoodGenerator
    {
        private IRandomPointGenerator generator;

        public FoodGenerator(IRandomPointGenerator generator)
        {
            this.generator = generator;
        }

        /// <summary>
        /// Determines a new location to place Food. Takes a List argument of all currently
        /// occupied Points. If the randomly-generated Food's location is present in the List,
        /// generate a new Point until there is no longer a collision.
        /// </summary>
        /// <param name="locations"></param>
        /// <returns>A Food item</returns>
        public Food Generate(List<Point> locations)
        {
            var food = new Food(generator.NextPoint());
            while (locations.Contains(food.Location))
            {
                food.Location = generator.NextPoint();
            }
            return food;
        }
    }
}