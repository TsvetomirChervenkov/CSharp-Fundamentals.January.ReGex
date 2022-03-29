using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T04.More_Excercise._Santas_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int key = int.Parse(Console.ReadLine());

            string msg;

            while ((msg = Console.ReadLine()) != "end")
            {
                string decodedWord = DecodeWord(msg, key);
                PrintGoodChild(decodedWord);
            }
        }
        static string DecodeWord(string msg, int key)
        {
            StringBuilder decodedWord = new StringBuilder();
            for (int i = 0; i < msg.Length; i++)
            {
                char currChar = (char)((int)msg[i] - key);
                decodedWord.Append(currChar);
            }
            return decodedWord.ToString();
        }
        static void PrintGoodChild(string decodedWord)
        {
            string validator = @"@(?<name>[A-Za-z]+)[^@\-!:>]+([!])(?<behavior>[G|N])\1";
            Match match = Regex.Match(decodedWord, validator);
            if (match.Groups["behavior"].Value == "G")
            {
                Console.WriteLine($"{match.Groups["name"].Value}");
            }
        }
    }
}
