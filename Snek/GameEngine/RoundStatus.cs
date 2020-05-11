namespace Snek.GameEngine
{
    /// <summary>
    /// Represents the current game instance's status, as well as whether the 
    /// timer should decrement (e.g., after the snek eats food).
    /// </summary>
    public class GameStatus
    {
        public bool GameOver { get; set; }
        public bool ShouldDecrement { get; }

        public GameStatus(bool gameOver = false, bool shouldDecrement = false)
        {
            GameOver = gameOver;
            ShouldDecrement = shouldDecrement;
        }
    }
}