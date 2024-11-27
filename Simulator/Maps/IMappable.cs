namespace Simulator.Maps;

public interface IMappable
{
    string Info { get; }
    Point Position { get; }
    void InitializeMapAndPosition(Map Map, Point position);
    void Go(Direction direction);
}
