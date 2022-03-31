using System;
using System.Linq;
using System.Text;

namespace T01.More_Excercise._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] loterryTickets = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var ticket in loterryTickets)
            {
                string currentTicket = ticket.Trim(' ');
                if (currentTicket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }
                else
                {
                    StringBuilder firstHalf = new StringBuilder();
                    StringBuilder secondHalf = new StringBuilder();
                    FirstHalf(firstHalf, currentTicket);
                    SecondHalf(secondHalf, currentTicket);
                    int counterDollar = 0;
                    int counterDS = 0;
                    int counterAT = 0;
                    int counterCHofka = 0;
                    foreach (var character in firstHalf.ToString())
                    {
                        foreach (var character2 in secondHalf.ToString())
                        {
                            if (character == '$' && character2 == '$')
                            {
                                counterDollar++;
                                break;
                            }
                            if (character == '#' && character2 == '#')
                            {
                                counterDS++;
                                break;
                            }
                            if (character == '@' && character2 == '@')
                            {
                                counterAT++;
                                break;
                            }
                            if (character == '^' && character2 == '^')
                            {
                                counterCHofka++;
                                break;
                            }
                            
                        }
                    }
                    if (counterDollar > 5)
                    {
                        if (counterDollar == 10)
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {counterDollar}$ Jackpot!");
                            continue;
                        }
                        Console.WriteLine($"ticket \"{currentTicket}\" - {counterDollar}$");
                    }
                    else if(counterCHofka > 5)
                    {
                        if (counterCHofka == 10)
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {counterCHofka}^ Jackpot!");
                            continue;
                        }
                        
                        Console.WriteLine($"ticket \"{currentTicket}\" - {counterCHofka}^");
                    }
                    else if (counterAT > 5)
                    {
                        if (counterAT == 10)
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {counterAT}@ Jackpot!");
                            continue;
                        }
                        Console.WriteLine($"ticket \"{currentTicket}\" - {counterAT}@");                     
                    }
                    else if(counterDS > 5)
                    {
                        if (counterDS == 10)
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - {counterDS}# Jackpot!");
                            continue;
                        }
                        Console.WriteLine($"ticket \"{currentTicket}\" - {counterDS}#");
                    }
                    else
                    {
                            Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                    }
                }
            }
        }
        static void FirstHalf(StringBuilder firstHalf, string ticket)
        {
            for (int i = 0; i < ticket.Length/2; i++)
            {
                firstHalf.Append(ticket[i]);
            }            
        }
        static void SecondHalf(StringBuilder secondHalf, string ticket)
        {
            for (int i = 10; i < ticket.Length; i++)
            {
                secondHalf.Append(ticket[i]);
            }
        }
    }
}
