using System.Text.Json.Serialization;

namespace Simulator.Maps;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Elf), nameof(Elf))]
[JsonDerivedType(typeof(Orc), nameof(Orc))]
[JsonDerivedType(typeof(Animals), nameof(Animals))]
[JsonDerivedType(typeof(Birds), nameof(Birds))]
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
