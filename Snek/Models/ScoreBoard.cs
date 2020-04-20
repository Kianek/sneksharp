namespace Snek.Models
{
    public class ScoreBoard
    {
        public int Score { get; private set; }

        public ScoreBoard() => Score = 0;

        public void AddPoint() => Score++;

        public void Reset() => Score = 0;
    }
}