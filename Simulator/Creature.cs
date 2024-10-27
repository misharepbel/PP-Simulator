using System;

namespace Simulator
{
    public class Creature
    {
        private readonly string? name;
        private int level;
        public Creature()
        {
            
        }
        public Creature(string name, int level=1)
        {
            Name = name;
            Level = level;
        }
        public string Name { get; init; }
        public int Level { get; set; }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }
        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
    }
}

