using Simulator.Maps;
using System.Text.Json.Serialization;
namespace Simulator;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
public abstract class Creature : IMappable
{
    private string name = "Unknown";
    private int level=1;
    protected int actionState=0;
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public void InitializeMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
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

    public abstract char Symbol { get; }

    new public string ToString()
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
    /// <summary>
    /// Go in a direction according to the rules of the map the creature is on.
    /// </summary>
    public void Go(Direction direction)
    {
        if (Map is not null)
        {
            Point newPosition = Map.Next(Position, direction);
            Map.Move(this, Position, newPosition);
            Position = newPosition;
        }
    }
}

