namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MapMovement.BounceNext;
        FNextDiagonal = MapMovement.BounceNextDiagonal;
    }

    /*public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y == SizeY - 1 ? SizeY - 2 : p.Y + 1)),
            Direction.Right => new Point((p.X == SizeX - 1 ? SizeX - 2 : p.X + 1), p.Y),
            Direction.Down => new Point(p.X, (p.Y == 0 ? 1 : p.Y - 1)),
            Direction.Left => new Point((p.X == 0 ? 1 : p.X - 1), p.Y),
            _ => default,
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point temp = p.NextDiagonal(d);
        if (!Exist(temp))
        {
            Direction tempNext = ChangeDirection(d, true);
            Direction tempPrev = ChangeDirection(d, false);
            if (Exist(temp.NextDiagonal(tempNext)))
            {
                return temp.NextDiagonal(tempNext);
            }
            if (Exist(temp.NextDiagonal(tempPrev)))
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
    }*/
}
