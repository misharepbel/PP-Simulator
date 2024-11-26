using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private List<Direction> _moves;
    private int thisMove = -1;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { get => Creatures.ElementAt(thisMove % Creatures.Count); }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get => _moves.ElementAt(thisMove).ToString().ToLower(); }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        int len = creatures.Count;
        if (len == 0)
        {
            throw new ArgumentException("You can't start a simulation with zero creatures.", nameof(creatures));
        }
        if (len != positions.Count)
        {
            throw new ArgumentException("Can't start simulation. Incompatible lists of creatures and positions.");
        }
        Map = map;
        Creatures = creatures;
        Positions = positions;
        for (int i = 0; i < len; i++)
        {
            Map.Add(creatures.ElementAt(i), positions.ElementAt(i));
        }
        Moves = moves;
        _moves = DirectionParser.Parse(Moves);
    }
    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>

    public void Turn()
    {
        thisMove++;
        if (Finished)
        {
            throw new Exception("Simulation has finished!");
        }
        CurrentCreature.Go(_moves.ElementAt(thisMove));
        if (thisMove == _moves.Count-1)
        {
            Finished = true;
        }
    }
}
