namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Dictionary<Point, List<IMappable>> fields;
    private readonly Rectangle check;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow.");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short.");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        fields = [];
        check = new(0, 0, SizeX - 1, SizeY - 1);
    }
    public int SizeX { get; }
    public int SizeY { get; }

    protected Func<Map, Point, Direction, Point>? FNext, FNextDiagonal;
    /// <summary>
    /// Add a mappable to the map.
    /// </summary>
    /// <param name="mappable">IMappable to add.</param>
    /// <param name="position">Position to add the mappable to.</param>
    public void Add(IMappable mappable, Point position)
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
    public void Remove(IMappable mappable, Point position)
    {
        if (fields.TryGetValue(position, out List<IMappable>? value))
        {
            value.Remove(mappable);
        }
    }

    /// <summary>
    /// Clear the map.
    /// </summary>
    public void Clear()
    {
        fields.Clear();
    }

    /// <summary>
    /// Move a mappable between two points on the map.
    /// </summary>
    /// <param name="mappable">IMappable to move.</param>
    /// <param name="start">Position to take the mappable from.</param>
    /// <param name="finish">Position to place the taken mappable.</param>
    public void Move(IMappable mappable, Point start, Point finish)
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
    public List<IMappable> At(Point position)
    {
        if (fields.TryGetValue(position, out List<IMappable>? value))
        {
            return value;
        }
        return [];
    }
    /// <summary>
    /// Look up every mappable at position (x, y)
    /// </summary>
    /// <param name="x">X-coordinate of the position to list mappables at.</param>
    /// <param name="y">Y-coordinate of the position to list mappables at.</param>
    /// <returns>List of mappables at position (x, y)</returns>
    public List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns>If p exists on the map.</returns>
    public virtual bool Exist(Point p)
    {
        return check.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;
}