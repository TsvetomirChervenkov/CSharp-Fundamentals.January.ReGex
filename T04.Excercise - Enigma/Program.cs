using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T04.Excercise___Enigma
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int messages = int.Parse(Console.ReadLine());
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < messages; i++)
            {
                string data = Console.ReadLine();

                int asciiNum = CounterOfStar(data);
                string dataDecrypted = DecryptData(data, asciiNum);

                string validation = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackDestroy>[A-D])![^@\-!:>]*->(?<soldiers>\d+)";
                Match match = Regex.Match(dataDecrypted, validation);
                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string attackOrDestroy = match.Groups["attackDestroy"].Value;
                    int soldies = int.Parse(match.Groups["soldiers"].Value);
                    if (attackOrDestroy == "A")
                    {
                        attacked.Add(planet);
                    }
                    if(attackOrDestroy == "D")
                    {
                        destroyed.Add(planet);
                    }
                }               
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var planet in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var planet2 in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet2}");
            }
        }   
        static int CounterOfStar(string data)
        {
            int counter = 0;    
            foreach (var character in data)
            {
                if (character == 'S' || character == 's' || character == 'T' || character == 't' || character == 'A' || character == 'a' || character == 'R'|| character == 'r')
                {
                    counter++;
                }
            }
            return counter;
        }
        static string DecryptData(string data, int digit)
        {
            string dataDecrypted = string.Empty;
            foreach (var character in data)
            {
                int asciiNum = (int)character - digit;
                dataDecrypted += (char)asciiNum;
            }
            return dataDecrypted;
        }
    }
}
