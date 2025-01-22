namespace Simulator.Maps;

internal static class MapMovement
{
    public static Point WallNext(Map map, Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == map.SizeY - 1 ? p : p.Next(d),
            Direction.Down => p.Y == 0 ? p : p.Next(d),
            Direction.Right => p.X == map.SizeX - 1 ? p : p.Next(d),
            Direction.Left => p.X == 0 ? p : p.Next(d),
            _ => default,
        };
    }
    public static Point WallNextDiagonal(Map map, Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == map.SizeY - 1 || p.X == map.SizeX - 1 ? p : p.NextDiagonal(d),
            Direction.Down => p.Y == 0 || p.X == 0 ? p : p.NextDiagonal(d),
            Direction.Right => p.X == map.SizeX - 1 || p.Y == 0 ? p : p.NextDiagonal(d),
            Direction.Left => p.X == 0 || p.Y == map.SizeY - 1 ? p : p.NextDiagonal(d),
            _ => default,
        };
    }
    public static Point TorusNext(Map map, Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == map.SizeY - 1 ? new Point(p.X, 0) : p.Next(d),
            Direction.Down => p.Y == 0 ? new Point(p.X, map.SizeY-1) : p.Next(d),
            Direction.Right => p.X == map.SizeX - 1 ? new Point(0, p.Y) : p.Next(d),
            Direction.Left => p.X == 0 ? new Point(map.SizeX - 1, p.Y) : p.Next(d),
            _ => default,
        };
    }
    public static Point TorusNextDiagonal(Map map, Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point((p.X+1)%map.SizeX, (p.Y + 1) % map.SizeY),
            Direction.Down => new Point((p.X==0 ? map.SizeX-1 : p.X-1), (p.Y == 0 ? map.SizeY - 1 : p.Y - 1)),
            Direction.Right => new Point((p.X + 1) % map.SizeX, (p.Y == 0 ? map.SizeY - 1 : p.Y - 1)),
            Direction.Left => new Point(p.X == 0 ? map.SizeX - 1 : p.X - 1, (p.Y + 1) % map.SizeY),
            _ => default,
        };
    }

    public static Point BounceNext(Map map, Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y == map.SizeY - 1 ? map.SizeY - 2 : p.Y + 1)),
            Direction.Right => new Point((p.X == map.SizeX - 1 ? map.SizeX - 2 : p.X + 1), p.Y),
            Direction.Down => new Point(p.X, (p.Y == 0 ? 1 : p.Y - 1)),
            Direction.Left => new Point((p.X == 0 ? 1 : p.X - 1), p.Y),
            _ => default,
        };
    }

    public static Point BounceNextDiagonal(Map map, Point p, Direction d)
    {
        Point temp = p.NextDiagonal(d);
        if (!map.Exist(temp))
        {
            Direction tempNext = ChangeDirection(d, true);
            Direction tempPrev = ChangeDirection(d, false);
            if (map.Exist(temp.NextDiagonal(tempNext)))
            {
                return temp.NextDiagonal(tempNext);
            }
            if (map.Exist(temp.NextDiagonal(tempPrev)))
            {
                return temp.NextDiagonal(tempPrev);
            }
            return temp.NextDiagonal(ChangeDirection(tempNext, true));
        }
        return temp;
    }

    private static Direction ChangeDirection(Direction d, bool next)
    {
        if (next)
        {
            return d switch
            {
                Direction.Up => Direction.Right,
                Direction.Right => Direction.Down,
                Direction.Down => Direction.Left,
                Direction.Left => Direction.Up,
                _ => default,
            };
        }
        return d switch
        {
            Direction.Up => Direction.Left,
            Direction.Left => Direction.Down,
            Direction.Down => Direction.Right,
            Direction.Right => Direction.Up,
            _ => default,
        };
    }
}
