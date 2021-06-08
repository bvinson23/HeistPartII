using System;

namespace HeistPartII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            int skill = bank.SecurityGuardScore - SkillLevel;

            Console.WriteLine($"{Name} is dealing with the guards. Decreased security {SkillLevel} points.");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has neutralized the guards!");
            }
        }
    }
}