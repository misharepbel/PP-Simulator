using System.Text.Json.Serialization;

namespace Simulator;

public class Human : Creature
{
    private int trading;
    public Human() { }
    public Human(string name = "Unknown", int level = 1, int trading = 1) : base(name, level)
    {
        Trading = trading;
    }
    public int Trading
    {
        get => trading;
        init => trading = Validator.Limiter(value, 0, 10);
    }
    [JsonIgnore]
    public override string Info
    {
        get { return $"{Name} [{Level}][{Trading}]"; }
    }
    [JsonIgnore]
    public override int Power
    {
        get { return (7*Level+3*Trading); }
    }
    [JsonIgnore]
    public override char Symbol => 'H';

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}. My trading is {Trading}.";
    }
}