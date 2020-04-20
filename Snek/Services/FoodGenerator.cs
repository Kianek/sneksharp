using Snek.Models;
using System.Collections.Generic;

namespace Snek.Services
{
    public class FoodGenerator
    {
        private IRandomPointGenerator generator;

        public FoodGenerator(IRandomPointGenerator generator)
        {
            this.generator = generator;
        }

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