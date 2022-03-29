using System;
using System.Text.RegularExpressions;

namespace T03.More_Excercise._Post_Office
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string[] allParts = code.Split('|');

            string firstPart = allParts[0];
            string secondPart = allParts[1];
            string thirdPart = allParts[2];

            string validatorCapitals = @"([#$%*&])(?<symbol>[A-Z])+\1";
            Match matchCapital = Regex.Match(firstPart, validatorCapitals);

            string validatorAscii = @"(?<ascii>\d+):(?<lenght>\d{2,})";
            MatchCollection matchAscii = Regex.Matches(secondPart, validatorAscii);

            string[] words = thirdPart.Split(' ');
            
            bool isfound = false;
            foreach (var character in matchCapital.Value)
            {
                isfound = false;
                foreach  (Match match in matchAscii)
                {
                    
                    int asciiDigit = int.Parse(match.Groups["ascii"].Value);
                    char currChar = (char)asciiDigit;
                    if (currChar == character)
                    {
                        int lenght = int.Parse(match.Groups["lenght"].Value);
                        foreach (var word in words)
                        {
                            
                            if (word.Length == lenght+1 && word[0] == currChar)
                            {
                                if (isfound)
                                {
                                    continue;
                                }
                                Console.WriteLine(word);
                                isfound = true;
                                   
                            }
                        }
                    }
                }
            }
            
        }
    }
}
