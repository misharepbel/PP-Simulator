using System.Text.Json.Serialization;

namespace Simulator;

public class Birds : Animals
{
    public Birds() { }
    public Birds(string description, uint size, bool canFly) : base(description, size) { CanFly = canFly; }
    public bool CanFly { get; set; } = true;
    [JsonIgnore]
    public override string Info
    {
        get { return $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>"; }
    }
    [JsonIgnore]
    public override char Symbol => CanFly ? 'B' : 'b';
    public override void Go(Direction direction)
    {
        if (Map is not null)
        {
            if (CanFly)
            {
                Point newPosition = Map.Next(Map.Next(Position, direction), direction);
                Map.Move(this, Position, newPosition);
                Position = newPosition;
            }
            else
            {
                Point newPosition = Map.NextDiagonal(Position, direction);
                Map.Move(this, Position, newPosition);
                Position = newPosition;
            }
        }
    }
}