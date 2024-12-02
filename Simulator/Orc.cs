namespace Simulator;

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
        init => rage = Validator.Limiter(value, 0, 10);
    }
    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; }
    }
    public override int Power
    {
        get { return (8 * Level + 2 * Rage); }
    }

    public override char Symbol => 'O';

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}. My rage is {Rage}.";
    }
    public void Hunt()
    {
        actionState++;
        if (actionState%2==0 && rage<10)
        {
            rage++;
        }
    }
}
