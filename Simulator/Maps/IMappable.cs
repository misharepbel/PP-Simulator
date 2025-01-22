using System.Text.Json.Serialization;

namespace Simulator.Maps;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Human), nameof(Human))]
[JsonDerivedType(typeof(Creeper), nameof(Creeper))]
public interface IMappable
{
    string Info { get; }
    Map? Map { get; }
    Point Position { get; }
    char Symbol { get; }
    string ToString();
    void InitializeMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
