namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string directions)
    {
        List<Direction> dirs = [];
        for (int i = 0; i < directions.Length; i++)
        {
            switch (directions[i])
            {
                case 'l':
                case 'L':
                    var l = Direction.Left;
                    dirs.Add(l);
                    break;
                case 'u':
                case 'U':
                    var u = Direction.Up;
                    dirs.Add(u);
                    break;
                case 'd':
                case 'D':
                    var d = Direction.Down;
                    dirs.Add(d);
                    break;
                case 'r':
                case 'R':
                    var r = Direction.Right;
                    dirs.Add(r);
                    break;
                default:
                    continue;
            }
        }
        return dirs;
    }
}
