using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private readonly List<Direction> _moves;
    private int thisMove = -1;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Mappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable { get => Mappables.ElementAt(thisMove % Mappables.Count); }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get => _moves.ElementAt(thisMove).ToString().ToLower(); }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        int len = mappables.Count;
        if (len == 0)
        {
            throw new ArgumentException("You can't start a simulation with zero mappables.", nameof(mappables));
        }
        if (len != positions.Count)
        {
            throw new ArgumentException("Can't start simulation. Incompatible lists of mappables and positions.");
        }
        Map = map;
        Mappables = mappables;
        Positions = positions;
        for (int i = 0; i < len; i++)
        {
            Map.Add(mappables.ElementAt(i), positions.ElementAt(i));
        }
        Moves = moves;
        _moves = DirectionParser.Parse(Moves);
        }
    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>

    public void Turn()
    {
        thisMove++;
        if (thisMove == _moves.Count)
        {
            Finished = true;
        }
        if (Finished)
        {
            throw new Exception("Simulation has finished!");
        }
        CurrentMappable.Go(_moves.ElementAt(thisMove));
        if (thisMove == _moves.Count)
        {
            Finished = true;
        }
    }
}
