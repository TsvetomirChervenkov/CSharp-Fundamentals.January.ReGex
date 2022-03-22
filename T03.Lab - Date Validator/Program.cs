using System;
using System.Text.RegularExpressions;

namespace T03.Lab___Date_Validator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string validator = @"\b(?<day>\d{2})([-\./])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            string date = Console.ReadLine();
            MatchCollection matches = Regex.Matches(date, validator);
            foreach (Match item in matches)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["month"].Value;
                var year = item.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
