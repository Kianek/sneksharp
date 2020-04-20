using Snek.Models;
using Snek.Services;

namespace Snek
{
    /// <summary>
    /// Launches a new game instance.
    /// </summary>
    class Launcher
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new GameOptionsBuilder();
            var engine = new Engine();

            Menu.Welcome();
            Menu.GetDifficulty(optionsBuilder);
            Menu.GetTileStyle(optionsBuilder);
            Menu.GetMapSize(optionsBuilder);
            engine.Run(optionsBuilder.Build());
        }
    }
}
