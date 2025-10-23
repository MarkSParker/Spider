using System.Text.RegularExpressions;

namespace SpiderProj
{
    /// <summary>
    /// Class: Provides a method to read and validate the user's input.
    /// </summary>
    internal static class Command
    {
        /// <summary>
        /// ReadAndParse: Read one command line and validate each space-separated token against a regex pattern.
        /// Return an array of valid tokens.
        /// </summary>
        /// <param name="patterns"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string[] ReadAndParse(params string[] patterns)
        {
            // Read the line and split into tokens
            var commands = Console.ReadLine()!.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            // Check there is the same number of tokens as patterns which validate tokens
            if (patterns.Length != commands.Length)
            {
                throw new ArgumentException($"Expected {patterns.Length} words on the command line.");
            }

            // Check each word matches the expected pattern.
            for (int i = 0; i < commands.Length; i++)
            {
                if (!Regex.IsMatch(commands[i], patterns[i]))
                {
                    throw new ArgumentException($"Word {i+1} is not in expected format.");
                }
            }

            return commands;
        }
    }
}
