using System;
using System.Collections.Generic;

namespace HeistPartII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| Welcome to Heist Builder. |");
            Console.WriteLine("-----------------------------");

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

            void Create()
            {
                Console.WriteLine($"There are {rolodex.Count} robbers in the rolodex.");
                Console.WriteLine();

                Console.WriteLine("Create a new crew member.");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                if (name.Length > 0)
                {
                    Console.WriteLine(@"Choose a specialty:
                1) Hacker (Disables alarms)
                2) Muscle (Disarms guards)
                3) Lock Specialist (Cracks vault) ");
                    int specialty = Int32.Parse(Console.ReadLine());

                    Console.Write($"Enter {name}'s Skill Level (1-100): ");
                    int skill = Int32.Parse(Console.ReadLine());

                    Console.Write($"Enter {name}'s cut of the loot (1-100 %): ");
                    int cut = Int32.Parse(Console.ReadLine());

                    if (specialty == 1)
                    {
                        Hacker hacker = new Hacker()
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = cut
                        };
                        rolodex.Add(hacker);
                    }
                    else if (specialty == 2)
                    {
                        Muscle muscle = new Muscle()
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = cut
                        };
                        rolodex.Add(muscle);
                    }
                    else if (specialty == 3)
                    {
                        LockSpecialist lockSpecialist = new LockSpecialist()
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = cut
                        };
                        rolodex.Add(lockSpecialist);
                    }
                    Create();
                }
                else
                {
                    Console.WriteLine("Time for the heist!!");
                }
            }
            Create();
        }
    }
}