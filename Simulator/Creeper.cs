using System.Text.Json.Serialization;

namespace Simulator;

public class Creeper : Creature
{
    private int attack;
    public Creeper() { }
    public Creeper(string name = "Unknown", int level = 1, int attack = 1) : base(name, level)
    {
        Attack = attack;
    }
    public int Attack
    {
        get => attack;
        init => attack = Validator.Limiter(value, 0, 10);
    }
    [JsonIgnore]
    public override string Info
    {
        get { return $"{Name} [{Level}][{Attack}]"; }
    }
    [JsonIgnore]
    public override int Power
    {
        get { return (8 * Level + 2 * Attack); }
    }
    [JsonIgnore]
    public override char Symbol => 'C';

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}. My attack is {Attack}.";
    }
}
