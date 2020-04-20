using Snek.Services;
using System;
using System.Text.RegularExpressions;

namespace Snek.Models
{
    public static class Menu
    {
        public static void Welcome()
        {
            Console.WriteLine("*--- Welcome to Snek ---*\n");
        }

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

        private static bool IsNonDigit(string value)
        {
            var match = new Regex(@"\D");
            return match.IsMatch(value);
        }
    }
}