using FluentAssertions;
using Snek.GameMap;
using Xunit;

namespace SnekTests
{
    public class RandomPointGeneratorTest
    {
        private int minSize = 0;
        private int maxSize = 4;

        [Fact]
        public void CanGenerateNewPoint()
        {
            var randomGenerator = new RandomPointGenerator(maxSize);
            var point = randomGenerator.NextPoint();

            point.Should().BeOfType<Point>();
            point.X.Should().BeInRange(minSize, maxSize - 1);
            point.Y.Should().BeInRange(minSize, maxSize - 1);
        }

        [Fact]
        public void CanGenerateUniquePointIfProvidedPointToExclude()
        {
            var randomGenerator = new RandomPointGenerator(maxSize);
            var pointToExclude = new Point(0, 0);
            var point = randomGenerator.NextPoint(pointToExclude);

            point.Should().NotBeSameAs(pointToExclude);
        }
    }
}