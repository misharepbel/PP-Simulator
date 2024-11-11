namespace Simulator;

public class Elf : Creature
{
    private int agility;
    public Elf() { }
    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    public override string Info
    {
        get { return $"{Name} [{Level}][{Agility}]"; }
    }
    public override int Power
    {
        get { return (7*Level+3*Agility); }
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}. My agility is {Agility}.");
    }
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        actionState++;
        if (actionState%3==0 && agility<10)
        {
            agility++;
        }
    }
}