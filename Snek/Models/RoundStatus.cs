namespace Snek.Models
{
    public class RoundStatus
    {
        public bool GameOver { get; set; }
        public bool ShouldDecrement { get; }

        public RoundStatus(bool gameOver = false, bool shouldDecrement = false)
        {
            GameOver = gameOver;
            ShouldDecrement = shouldDecrement;
        }
    }
}