namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<IMappable>[,] fields;
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
        fields = new List<IMappable>[sizeX, sizeY];
        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                fields[i, j] = new List<IMappable>();
            }
        }
    }
    /// <summary>
    /// Add a mappable to the map.
    /// </summary>
    /// <param name="mappable">IMappable to add.</param>
    /// <param name="position">Position to add the mappable to.</param>
    public override void Add(IMappable mappable, Point position)
    {
        fields[position.X, position.Y].Add(mappable);
        mappable.InitializeMapAndPosition(this, position);
    }
    /// <summary>
    /// Remove a mappable from the map.
    /// </summary>
    /// <param name="mappable">IMappable to remove.</param>
    /// <param name="position">Position to remove the mappable from.</param>
    public override void Remove(IMappable mappable, Point position)
    {
        fields[position.X, position.Y].Remove(mappable);
    }
    /// <summary>
    /// Move a mappable between two points on the map.
    /// </summary>
    /// <param name="mappable">IMappable to move.</param>
    /// <param name="start">Position to take the mappable from.</param>
    /// <param name="finish">Position to place the taken mappable.</param>
    public override void Move(IMappable mappable, Point start, Point finish)
    {
        fields[start.X, start.Y].Remove(mappable);
        fields[finish.X, finish.Y].Add(mappable);
    }
    /// <summary>
    /// Look up every mappable at position
    /// </summary>
    /// <param name="position">Position to list mappables at.</param>
    /// <returns>List of mappables at position</returns>
    public override List<IMappable> At(Point position)
    {
        return fields[position.X, position.Y];
    }
    /// <summary>
    /// Look up every mappable at position (x, y)
    /// </summary>
    /// <param name="x">X-coordinate of the position to list mappables at.</param>
    /// <param name="y">Y-coordinate of the position to list mappables at.</param>
    /// <returns>List of mappables at position (x, y)</returns>
    public override List<IMappable> At(int x, int y)
    {
        return fields[x, y];
    }
}
