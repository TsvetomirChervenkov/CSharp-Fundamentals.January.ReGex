using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01.Excercise__Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitures = new List<string>();

            string validator = @">>(?<name>[A-Za-z]+)<<(?<price>[0-9]+\.?[0-9]*|\.[0-9]+)!(?<quantity>\d+)\b";
            string input = string.Empty;

            decimal totalPrice = 0;

            while((input = Console.ReadLine()) != "Purchase")
            {                
                Match match = Regex.Match(input, validator);
                if (match.Success)
                {
                    string furniture = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    furnitures.Add(furniture);
                    totalPrice += price * quantity;
                }
            }
            Console.WriteLine($"Bought furniture:");
            foreach (var item in furnitures)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
