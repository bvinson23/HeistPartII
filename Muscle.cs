using System;

namespace HeistPartII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; set; }
        public void PerformSkill(Bank bank)
        {
            int skill = bank.SecurityGuardScore - SkillLevel;

            Console.WriteLine($"{Name} is dealing with the guards. Decreased security {SkillLevel} points.");

            bank.SecurityGuardScore = skill;

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has neutralized the guards!");
            }
        }
    }
}