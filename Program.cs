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
                PercentageCut = 40,
                Specialty = "Lock Specialist"
            };

            LockSpecialist pontiac = new LockSpecialist()
            {
                Name = "Pontiac Bandit",
                SkillLevel = 65,
                PercentageCut = 50,
                Specialty = "Lock Specialist"
            };

            Hacker boyle = new Hacker()
            {
                Name = "Charles Boyle",
                SkillLevel = 35,
                PercentageCut = 20,
                Specialty = "Hacker"
            };

            Hacker amy = new Hacker()
            {
                Name = "Amy Santiago",
                SkillLevel = 45,
                PercentageCut = 30,
                Specialty = "Hacker"
            };

            Muscle rosa = new Muscle()
            {
                Name = "Rosa Diaz",
                SkillLevel = 60,
                PercentageCut = 35,
                Specialty = "Muscle"
            };

            Muscle terry = new Muscle()
            {
                Name = "Terry Jeffords",
                SkillLevel = 75,
                PercentageCut = 50,
                Specialty = "Muscle"
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
                            PercentageCut = cut,
                            Specialty = "Hacker"
                        };
                        rolodex.Add(hacker);
                    }
                    else if (specialty == 2)
                    {
                        Muscle muscle = new Muscle()
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = cut,
                            Specialty = "Muscle"
                        };
                        rolodex.Add(muscle);
                    }
                    else if (specialty == 3)
                    {
                        LockSpecialist lockSpecialist = new LockSpecialist()
                        {
                            Name = name,
                            SkillLevel = skill,
                            PercentageCut = cut,
                            Specialty = "Lock Specialist"
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

            Random i = new Random();
            Bank bank = new Bank()
            {
                AlarmScore = i.Next(0, 100),
                VaultScore = i.Next(0, 100),
                SecurityGuardScore = i.Next(0, 100),
                CashOnHand = i.Next(50000, 1000000)
            };

            Console.WriteLine("----------------");
            Console.WriteLine("| Recon Report |");
            Console.WriteLine("----------------");
            Console.WriteLine();

            if (bank.AlarmScore > bank.VaultScore && bank.AlarmScore > bank.SecurityGuardScore)
            {
                if (bank.VaultScore > bank.SecurityGuardScore)
                {
                    Console.WriteLine("Most Secure: Alarm       Least Secure: Security Guard");
                }
                else
                {
                    Console.WriteLine("Most Secure Alarm        Least Secure: Vault");
                }
            }
            else if (bank.VaultScore > bank.AlarmScore && bank.VaultScore > bank.SecurityGuardScore)
            {
                if (bank.AlarmScore > bank.SecurityGuardScore)
                {
                    Console.WriteLine("Most Secure: Vault       Least Secure: Security Guard");
                }
                else
                {
                    Console.WriteLine("Most Secure: Vault       Least Secure: Alarm");
                }
            }
            else
            {
                if (bank.VaultScore > bank.AlarmScore)
                {
                    Console.WriteLine("Most Secure: Security Guard      Least Secure: Alarm");
                }
                else
                {
                    Console.WriteLine("Most Secure: Security Guard      Least Secure: Vault");
                }
            }
            Console.WriteLine("------------------------------------------------------------");

            int index = 1;
            List<IRobber> crew = new List<IRobber>();

            Console.WriteLine("---------------");
            Console.WriteLine("| The Rolodex |");
            Console.WriteLine("---------------");
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($@"Name: {robber.Name}
                Skill: {robber.SkillLevel}
                Cut of the Loot: {robber.PercentageCut}
                RobberId: {index}
                Specialty: {robber.Specialty}
                ");
                index++;
            }
        }
    }
}