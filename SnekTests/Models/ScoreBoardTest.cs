using FluentAssertions;
using Snek.GameEngine;
using Xunit;

namespace SnekTests.Models
{
    public class ScoreBoardTest
    {
        [Fact]
        public void CanAddPointsToScore()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.AddPoint();
            scoreBoard.AddPoint();

            scoreBoard.Score.Should().Be(2);
        }

        [Fact]
        public void CanResetPointsToZero()
        {
            var scoreBoard = new ScoreBoard();
            scoreBoard.AddPoint();
            scoreBoard.AddPoint();
            scoreBoard.Reset();

            scoreBoard.Score.Should().Be(0);
        }

    }
}