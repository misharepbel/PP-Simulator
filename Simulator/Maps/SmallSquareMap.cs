namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MapMovement.WallNext;
        FNextDiagonal = MapMovement.WallNextDiagonal;
    }
    /*public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == Size - 1 ? p : p.Next(d),
            Direction.Down => p.Y == 0 ? p : p.Next(d),
            Direction.Right => p.X == Size - 1 ? p : p.Next(d),
            Direction.Left => p.X == 0 ? p : p.Next(d),
            _ => default,
        };
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => p.Y == Size - 1 || p.X == Size - 1 ? p : p.NextDiagonal(d),
            Direction.Down => p.Y == 0 || p.X == 0 ? p : p.NextDiagonal(d),
            Direction.Right => p.X == Size - 1 || p.Y == 0 ? p : p.NextDiagonal(d),
            Direction.Left => p.X == 0 || p.Y == Size - 1 ? p : p.NextDiagonal(d),
            _ => default,
        };
    }*/
}