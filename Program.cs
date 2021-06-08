using System;
using System.Collections.Generic;

namespace HeistPartII
{
    class Program
    {
        static void Main(string[] args)
        {
            LockSpecialist jake = new LockSpecialist()
            {
                Name = "Jake Peralta",
                SkillLevel = 55,
                PercentageCut = 40
            };

            LockSpecialist pontiac = new LockSpecialist()
            {
                Name = "Pontiac Bandit",
                SkillLevel = 65,
                PercentageCut = 50
            };

            Hacker boyle = new Hacker()
            {
                Name = "Charles Boyle",
                SkillLevel = 35,
                PercentageCut = 20
            };

            Hacker amy = new Hacker()
            {
                Name = "Amy Santiago",
                SkillLevel = 45,
                PercentageCut = 30
            };

            Muscle rosa = new Muscle()
            {
                Name = "Rosa Diaz",
                SkillLevel = 60,
                PercentageCut = 35
            };

            Muscle terry = new Muscle()
            {
                Name = "Terry Jeffords",
                SkillLevel = 75,
                PercentageCut = 50
            };

            List<IRobber> rolodex = new List<IRobber>()
            {
                jake, pontiac, amy, boyle, rosa, terry
            };

            Console.WriteLine("-----------------------------");
            Console.WriteLine("| Welcome to Heist Builder. |");
            Console.WriteLine("-----------------------------");

            Console.WriteLine($"There are {rolodex.Count} robbers in the rolodex.");


        }
    }
}
