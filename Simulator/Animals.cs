using Simulator.Maps;
using System.Text.Json.Serialization;

namespace Simulator;

public class Animals : IMappable
{
    public Animals() { }
    public Animals(string description, uint size)
    {
        Description = description;
        Size = size;
    }
    private string description = "Capybaras";

    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;
    [JsonIgnore]
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public Map? Map { get; private set; }
    public Point Position { get; protected set; }

    [JsonIgnore]
    public virtual char Symbol => 'A';

    public virtual void Go(Direction direction)
    {
        if (Map is not null)
        {
            Point newPosition = Map.Next(Position, direction);
            Map.Move(this, Position, newPosition);
            Position = newPosition;
        }
    }

    public void InitializeMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }

    new public string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }
}
