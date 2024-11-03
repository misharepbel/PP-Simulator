using System;
using System.Reflection.Emit;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage;
        public Orc() { }
        public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        public int Rage
        {
            get => rage;
            init
            {
                if (value < 0)
                {
                    rage = 0;
                }
                else if (value > 10)
                {
                    rage = 10;
                }
                else
                {
                    rage = value;
                }
            }
        }
        public override int Power
        {
            get { return (8 * Level + 2 * Rage); }
        }
        override public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}. My rage is {Rage}.");
        }
        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            actionState++;
            if (actionState%2==0 && rage<10)
            {
                rage++;
            }
        }
    }
}
