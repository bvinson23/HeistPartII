using System;
using System.Collections.Generic;
using System.Linq;

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

            void Recon()
            {
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
            }
            Console.WriteLine("------------------------------------------------------------");

            List<IRobber> crew = new List<IRobber>();

            while (true)
            {
                Recon();
                Console.WriteLine("---------------");
                Console.WriteLine("| The Rolodex |");
                Console.WriteLine("---------------");

                int index = 1;
                var selectionList = rolodex.Except(crew).ToList();
                foreach (IRobber robber in selectionList)
                {
                    Console.WriteLine($@"Name: {robber.Name}
                Skill: {robber.SkillLevel}
                Cut of the Loot: {robber.PercentageCut}%
                RobberId: {index}
                Specialty: {robber.Specialty}
                ");
                    index++;
                }

                Console.Write("Enter the index of the robber you would like to add to your crew: ");
                string member = Console.ReadLine();
                if (member == "")
                {
                    break;
                }

                int cut = 0;
                foreach (IRobber r in crew)
                {
                    cut += r.PercentageCut;
                }
                cut = cut + selectionList[Int32.Parse(member) - 1].PercentageCut;
                if (cut < 100)
                {
                    crew.Add(selectionList[Int32.Parse(member) - 1]);
                }
                else
                {
                    Console.WriteLine("They're take is too high, choose someone else.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("------------------");
            Console.WriteLine("| Time to Heist! |");
            Console.WriteLine("------------------");

            foreach (IRobber r in crew)
            {
                r.PerformSkill(bank);
            }

            if (bank.IsSecure())
            {
                Console.WriteLine("You've lost. I said good day sir!");
            }
            else
            {
                Console.WriteLine("You won!");
                int cut = 0;
                int payout = 0;
                foreach (IRobber r in crew)
                {
                    cut += r.PercentageCut;
                    payout = r.PercentageCut * bank.CashOnHand / 100;
                    Console.WriteLine($"{r.Name} got ${payout}");
                }

                Console.WriteLine($"After paying your crew, you're left with ${bank.CashOnHand - payout}");
            }
        }
    }
}