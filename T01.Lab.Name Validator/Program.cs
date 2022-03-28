 using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string validator = @"\b[A-Z][a-z]+ \b[A-Z][a-z]+";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, validator);
            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
        }
    }
}
