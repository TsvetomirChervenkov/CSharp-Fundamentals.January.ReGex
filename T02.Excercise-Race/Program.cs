using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02.Excercise_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Score = new Dictionary<string, int>();
            string validatorParticipants = @"\b[A-z}[a-z]+\b";
            string participants = Console.ReadLine();
            MatchCollection matchNames = Regex.Matches(participants, validatorParticipants);
            foreach (Match match in matchNames)
            {
                Score.Add(match.Value, 0);
            }

            string inputData = string.Empty;
            while ((inputData = Console.ReadLine()) != "end of race")
            {
                string AlphaValidator = @"[A-Za-z]";
                string name = string.Empty;
                MatchCollection matches = Regex.Matches(inputData, AlphaValidator);
                foreach (Match item in matches)
                {
                    name += item.Value;
                }
                if (Score.ContainsKey(name))
                {
                    int distance = 0;
                    string numberValidator = @"\d{1}";
                    MatchCollection matches2 = Regex.Matches(inputData, numberValidator);
                    foreach (Match item2 in matches2)
                    {
                        distance += int.Parse(item2.Value);
                    }
                    Score[name] += distance;
                }
            }
            var Score1 = Score.OrderByDescending(x => x.Value).Take(3);
            int counter = 0;
            foreach (var item in Score1)
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
            } 
        }
    }
}
