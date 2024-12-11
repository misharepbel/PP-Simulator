namespace Simulator.Maps;

public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");
        }
        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");
        }
        fields = [];
    }
    /// <summary>
    /// Add a mappable to the map.
    /// </summary>
    /// <param name="mappable">IMappable to add.</param>
    /// <param name="position">Position to add the mappable to.</param>
    public override void Add(IMappable mappable, Point position)
    {
        if (fields.TryGetValue(position, out List<IMappable>? value))
        {
            value.Add(mappable);
        }
        else
        {
            fields.Add(position, [mappable]);
        }
        mappable.InitializeMapAndPosition(this, position);
    }
    /// <summary>
    /// Remove a mappable from the map.
    /// </summary>
    /// <param name="mappable">IMappable to remove.</param>
    /// <param name="position">Position to remove the mappable from.</param>
    public override void Remove(IMappable mappable, Point position)
    {
        if (fields.TryGetValue(position, out List<IMappable>? value))
        {
            value.Remove(mappable);
        }
    }
    /// <summary>
    /// Move a mappable between two points on the map.
    /// </summary>
    /// <param name="mappable">IMappable to move.</param>
    /// <param name="start">Position to take the mappable from.</param>
    /// <param name="finish">Position to place the taken mappable.</param>
    public override void Move(IMappable mappable, Point start, Point finish)
    {
        if (fields.TryGetValue(start, out List<IMappable>? startList))
        {
            startList.Remove(mappable);
        }
        if (fields.TryGetValue(finish, out List<IMappable>? finishList))
        {
            finishList.Add(mappable);
        }
        else
        {
            fields.Add(finish, [mappable]);
        }
    }
    /// <summary>
    /// Look up every mappable at position
    /// </summary>
    /// <param name="position">Position to list mappables at.</param>
    /// <returns>List of mappables at position</returns>
    public override List<IMappable> At(Point position)
    {
        if (fields.ContainsKey(position))
        {
            return fields[position];
        }
        return [];
    }
    /// <summary>
    /// Look up every mappable at position (x, y)
    /// </summary>
    /// <param name="x">X-coordinate of the position to list mappables at.</param>
    /// <param name="y">Y-coordinate of the position to list mappables at.</param>
    /// <returns>List of mappables at position (x, y)</returns>
    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
