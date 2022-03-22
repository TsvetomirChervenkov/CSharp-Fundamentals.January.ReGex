using System;
using System.Text.RegularExpressions;

namespace T03.Excercie___SoftUniBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string validator = @"%(?<name>[A-Z]{1}[a-z]+)%[^%|$.]*?<(?<product>\w+)>[^%|$.]*?\|(?<qunatity>\d+)\|[^%|$.]*?(?<price>\d+(\.\d+)?)\$";
            string input;
            decimal totalPrice = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, validator);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int qty = int.Parse(match.Groups["qunatity"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    Console.WriteLine($"{name}: {product} - {qty*price:f2}");
                    totalPrice+=qty*price;
                }
            }
            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
