using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02.Lab___Phone_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string validator = @"\+359(-| )2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, validator);
            string[] phones = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
