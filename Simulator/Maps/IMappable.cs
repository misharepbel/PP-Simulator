namespace Simulator.Maps;

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
