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
    public abstract string Greeting();
    public void Upgrade()
    {
        if (level<10)
        {
            level++;
        }
    }
    public string Go(Direction direction)
    {
        string dir = Char.ToLower(direction.ToString()[0]) + direction.ToString().Substring(1);
        return $"{Name} goes {dir}.";
    }
    public string[] Go(Direction[] directions)
    {
        var strings = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            strings[i] = this.Go(directions[i]);
        }
        return strings;
    }
    public string[] Go(string directions)
    {
        return this.Go(DirectionParser.Parse(directions));
    }
}

