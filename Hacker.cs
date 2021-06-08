using System;

namespace HeistPartII
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            int skill = bank.AlarmScore - SkillLevel;
            
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased scurity {SkillLevel} points.");

            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
    }
}