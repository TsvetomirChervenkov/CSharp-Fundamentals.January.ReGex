using System;
using System.Text.RegularExpressions;

namespace T06.Excercise_E_mailValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string info = Console.ReadLine();
            string validator = @"(?<=\s|^)[a-z0-9]+[\.\-_a-z0-9]+@[a-z\-]+\.([\.A-Za-z]+)+\b";

            MatchCollection matches = Regex.Matches(info, validator);

            foreach (Match item in matches)
            {
                string value = item.Value.TrimStart('.');
                Console.WriteLine(item.Value);
            }
        }
    }
}
