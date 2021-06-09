using System;

namespace HeistPartII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; set; }
        public void PerformSkill(Bank bank)
        {
            int skill = bank.VaultScore - SkillLevel;

            Console.WriteLine($"{Name} is picking the vault lock. Decreased lock {SkillLevel} points.");

            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has picked the lock!");
            }
        }
    }
}