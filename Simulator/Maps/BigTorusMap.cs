namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MapMovement.TorusNext;
        FNextDiagonal = MapMovement.TorusNextDiagonal;
    }

    /*public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point(p.X, (p.Y + 1) % SizeY),
            Direction.Down => p.Y == 0 ? new Point(p.X, SizeY - 1) : p.Next(d),
            Direction.Right => new Point((p.X + 1) % SizeX, p.Y),
            Direction.Left => p.X == 0 ? new Point(SizeX - 1, p.Y) : p.Next(d),
            _ => default,
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => new Point((p.X + 1) % SizeX, (p.Y + 1) % SizeY),
            Direction.Down => new Point(p.X == 0 ? SizeX - 1 : p.X - 1, p.Y == 0 ? SizeY - 1 : p.Y - 1),
            Direction.Right => new Point((p.X + 1) % SizeX, p.Y == 0 ? SizeY - 1 : p.Y - 1),
            Direction.Left => new Point(p.X == 0 ? SizeX - 1 : p.X - 1, (p.Y + 1) % SizeY),
            _ => default,
        };
    }*/
}
