using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T02.More_Exercise._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string validator = @"(?<symbols>[^\d]+)(?<digit>\d+)";
            MatchCollection matches = Regex.Matches(text, validator);

            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                string currentText = match.Groups["symbols"].Value.ToUpper();
                int currDigit = int.Parse(match.Groups["digit"].Value);
                for (int i = 0; i < currDigit; i++)
                {
                    sb.Append(currentText);
                }
            }
            int charCounter = 0;
            string allChars = string.Empty ;
            for (int i = 0; i < sb.Length; i++)
            {
                char currentChar = sb[i];
                if (!allChars.Contains(currentChar))
                {
                    charCounter++;
                    allChars = allChars + currentChar;
                }
            }
            Console.WriteLine($"Unique symbols used: {charCounter}");
            Console.WriteLine(sb);
        }
    }
}
