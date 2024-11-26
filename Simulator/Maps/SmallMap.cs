namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>[,] fields;
    //This nullable didn't really make sense to me
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");
        }
        fields = new List<Creature>[sizeX, sizeY];
        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                fields[i, j] = new List<Creature>();
            }
        }
    }
    /// <summary>
    /// Add a creature to the map.
    /// </summary>
    /// <param name="creature">Creature to add.</param>
    /// <param name="position">Position to add the creature to.</param>
    public override void Add(Creature creature, Point position)
    {
        fields[position.X, position.Y].Add(creature);
        creature.InitializeMapAndPosition(this, position);
    }
    /// <summary>
    /// Remove a creature from the map.
    /// </summary>
    /// <param name="creature">Creature to remove.</param>
    /// <param name="position">Position to remove the creature from.</param>
    public override void Remove(Creature creature, Point position)
    {
        fields[position.X, position.Y].Remove(creature);
    }
    /// <summary>
    /// Move a creature between two points on the map.
    /// </summary>
    /// <param name="creature">Creature to move.</param>
    /// <param name="start">Position to take the creature from.</param>
    /// <param name="finish">Position to place the taken creature.</param>
    public override void Move(Creature creature, Point start, Point finish)
    {
        fields[start.X, start.Y].Remove(creature);
        fields[finish.X, finish.Y].Add(creature);
    }
    /// <summary>
    /// Look up every creature at position
    /// </summary>
    /// <param name="position">Position to list creatures at.</param>
    /// <returns>List of creatures at position</returns>
    public override List<Creature> At(Point position)
    {
        return fields[position.X, position.Y];
    }
    /// <summary>
    /// Look up every creature at position (x, y)
    /// </summary>
    /// <param name="x">X-coordinate of the position to list creatures at.</param>
    /// <param name="y">Y-coordinate of the position to list creatures at.</param>
    /// <returns>List of creatures at position (x, y)</returns>
    public override List<Creature> At(int x, int y)
    {
        return fields[x, y];
    }
}
