using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T05.Excercise___NetherRealms
{
    class Monster
    {
        public Monster(int health, double dmg)
        {
            this.Health = health;
            this.Dmg = dmg;
        }
        public int Health { get; set; }
        public double Dmg { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Monster> listOfMonsters = new SortedDictionary<string, Monster>();

            string inputData = Console.ReadLine();
            string validator = @"(?<name>[^\s,]+)";
            MatchCollection monsters = Regex.Matches(inputData, validator);
            foreach (Match monster in monsters)
            {
                int currMonsterHP = Health(monster);
                double currMonsterDMG = Dmg(monster);
                Monster newMonster = new Monster(currMonsterHP, currMonsterDMG);
                listOfMonsters.Add(monster.Value, newMonster);
            }

            foreach (var monster in listOfMonsters)
            {
                Console.WriteLine($"{monster.Key} - {monster.Value.Health} health, {monster.Value.Dmg:f2} damage");
            }
        }
        static int Health(Match monster)
        {
            int health = 0;
            foreach (char character in monster.Value)
            {
                if (char.IsDigit(character))
                {
                    continue;
                }
                if (character == '+' || character == '-' || character == '*' || character == '/' || character == '.')
                {
                    continue;
                }
                health += (int)character;
            }
            return health;
        }
        static double Dmg(Match monster)
        {
            double damage = 0.00;

            string validatorDmg = @"(?<digit>[+-]?(?<digit>\d+(\.\d+)?))";
            string champ = monster.Value;

            MatchCollection numsForDmg = Regex.Matches(champ, validatorDmg);
            foreach (Match num in numsForDmg)
            {
                damage += (double.Parse(num.Value));
            }
            foreach (var character in monster.Value)
            {
                if (character == '*')
                {
                    damage *= 2;
                }
                if (character == '/')
                {
                    damage /= 2;
                }
            }
            return damage;
        }
    }
}
