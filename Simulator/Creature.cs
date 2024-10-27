using System;

namespace Simulator
{
    public class Creature
    {
        private string name = "Unknown";
        private int level;
        public Creature() { }
        public Creature(string name, int level=1)
        {
            Name = name;
            Level = level;
        }
        public string Name
        {
            get => name;
            init
            {
                value = value.Trim();
                if (value.Length > 25)
                {
                    value = value.Substring(0, 25);
                }
                value = value.TrimEnd();
                if (value.Length < 3)
                {
                    value += new String('#', 3 - value.Length);
                }
                if (value[0] is >= 'a' and <= 'z')
                {
                    value = (char)(value[0] - 32) + value.Substring(1);
                }
                name = value;
            }
        }
        public int Level
        {
            get => level;
            init
            {
                if (value < 1)
                {
                    level = 1;
                }
                else if (value > 10)
                {
                     level = 10;
                }
                else
                {
                    level = value;
                }
            }
        }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }
        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
        public void Upgrade()
        {
            if (level<10)
            {
                level++;
            }
        }
    }
}

