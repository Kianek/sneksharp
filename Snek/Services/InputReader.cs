using System;
namespace Snek.Services
{
    public static class InputReader
    {
        /// <summary>
        /// Reads the user's direction input without displaying it to the console.
        /// </summary>
        /// <returns>the ConsoleKeyInfo object representing one of the arrow keys.</returns>
        public static ConsoleKeyInfo Read()
        {
            return Console.ReadKey(true);
        }
    }
}