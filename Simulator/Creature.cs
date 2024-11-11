namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level=1;
    protected int actionState=0;
    public Creature() { }
    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }
    public abstract string Info { get; }
    public abstract int Power { get; }
    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }
    public abstract void SayHi();
    public void Upgrade()
    {
        if (level<10)
        {
            level++;
        }
    }
    public void Go(Direction direction)
    {
        string dir = (char)(direction.ToString()[0] + 32) + direction.ToString().Substring(1);
        Console.WriteLine ($"{Name} goes {dir}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            this.Go(direction);
        }
    }
    public void Go(string directions)
    {
        this.Go(DirectionParser.Parse(directions));
    }
}

