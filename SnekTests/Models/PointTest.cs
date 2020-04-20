using FluentAssertions;
using Snek.Models;
using Xunit;

namespace SnekTests
{
    public class PointTest
    {
        [Fact]
        public void CanCheckPointsForEquality()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(1, 1);

            var result = p1 == p2;
            result.Should().BeTrue("the coordinates are the same");
        }

        [Fact]
        public void CanCheckPointsForInequality()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(7, 4);

            var result = p1 != p2;
            result.Should().BeTrue("the coordinates are the different");
        }
    }
}