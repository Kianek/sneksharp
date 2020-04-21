using Snek.Services;
using System;
using System.Text.RegularExpressions;

namespace Snek.Models
{
    /// <summary>
    /// Welcomes the user and presents the game configuration options.
    /// </summary>
    public static class Menu
    {
        public static void Welcome()
        {
            Console.WriteLine("*--- Welcome to Snek ---*\n");
        }

        /// <summary>
        /// Prompts the user to choose a difficulty setting.
        /// </summary>
        /// <param name="builder"></param>
        public static void GetDifficulty(IGameOptionsBuilder builder)
        {
            int choice;
            do
            {
                Console.WriteLine("*--- Difficulty ---*");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Normal");
                Console.WriteLine("3. Hard");
                Console.Write("Choose your difficulty: ");
                choice = ReadChoice();
            } while (choice < 1 || 3 < choice);

            builder.SetDifficulty(EnumMapper.GetDifficulty(choice));
        }

        /// <summary>
        /// Prompts the user to choose a tile style.
        /// </summary>
        /// <param name="builder"></param>
        public static void GetTileStyle(IGameOptionsBuilder builder)
        {
            int choice;
            do
            {
                Console.WriteLine("*--- Map Style ---*");
                Console.WriteLine("1. Square brackets - [ ]");
                Console.WriteLine("2. Parentheses - ( )");
                Console.WriteLine("3. Curly braces - { }");
                Console.Write("Choose the map style: ");
                choice = ReadChoice();
            } while (choice < 1 || 3 < choice);

            builder.SetTileStyle(EnumMapper.GetTileStyle(choice));
        }

        /// <summary>
        /// Prompts the user to select a map size.
        /// </summary>
        /// <param name="builder"></param>
        public static void GetMapSize(IGameOptionsBuilder builder)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose the map size: ");
                Console.WriteLine("1. Large");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Small");
                choice = ReadChoice();
            } while (choice < 1 || 3 < choice);

            builder.SetMapSize(EnumMapper.GetMapSize(choice));
        }

        /// <summary>
        /// Reads the user's menu options choice, and validates it.
        /// </summary>
        /// <returns>An integer value representing the user's choice.</returns>
        private static int ReadChoice()
        {
            var input = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }
            if (IsNonDigit(input))
            {
                return 0;
            }

            return Int32.Parse(input);
        }

        /// <summary>
        /// Uses Regex to check whether a given string contains any non-digit characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsNonDigit(string value)
        {
            var match = new Regex(@"\D");
            return match.IsMatch(value);
        }
    }
}