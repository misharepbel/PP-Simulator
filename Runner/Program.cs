using Simulator;
using Simulator.Maps;

internal class Program
{
    private static void Lab5a()
    {
        Point p1 = new(10, 25);
        Point p2 = new(-4, 3);
        try
        {
            Console.Write("r1: ");
            Rectangle r1 = new(-1, -8, -4, -8);
            Console.WriteLine(r1);
            Console.WriteLine($"Is p1{p1} in r1({r1})? {(r1.Contains(p1) ? "Yes" : "No")}.");
            Console.WriteLine($"Is p2{p2} in r1({r1})? {(r1.Contains(p2) ? "Yes" : "No")}.\n");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.Write("r2: ");
            Rectangle r2 = new(new Point(1, 3), new Point(11, 43));
            Console.WriteLine(r2);
            Console.WriteLine($"Is p1{p1} in r2({r2})? {(r2.Contains(p1) ? "Yes" : "No")}.");
            Console.WriteLine($"Is p2{p2} in r2({r2})? {(r2.Contains(p2) ? "Yes" : "No")}.\n");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.Write("r3: ");
            Rectangle r3 = new(1, 5, 4, 0);
            Console.WriteLine(r3);
            Console.WriteLine($"Is p1{p1} in r3({r3})? {(r3.Contains(p1) ? "Yes" : "No")}.");
            Console.WriteLine($"Is p2{p2} in r3({r3})? {(r3.Contains(p2) ? "Yes" : "No")}.\n");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.Write("r4: ");
            Rectangle r4 = new(50, 19, -4, -100);
            Console.WriteLine(r4);
            Console.WriteLine($"Is p1{p1} in r4({r4})? {(r4.Contains(p1) ? "Yes" : "No")}.");
            Console.WriteLine($"Is p2{p2} in r4({r4})? {(r4.Contains(p2) ? "Yes" : "No")}.\n");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
    }
    private static void Lab5b()
    {
        Point[] points = {new(10, 15), new(-4, 3), new(8, 1), new(0, 9), new(7, 19), new(4, 0), new (7, 7)};
        try
        {
            Console.WriteLine("m1:");
            SmallSquareMap m1 = new(4);
            Console.WriteLine("Map created!");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.WriteLine("m2:");
            SmallSquareMap m2 = new(24);
            Console.WriteLine("Map created!");
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.WriteLine("m3:");
            SmallSquareMap m3 = new(20);
            Console.WriteLine("Map created!");
            foreach (var point in points)
            {
                Console.WriteLine($"{point} {(m3.Exist(point) ? "exists" : "doesn't exist")} in m3.");
            }
            Console.WriteLine();
            Console.WriteLine($"{points[0]} upwards: {m3.Next(points[0], Direction.Up)}");
            Console.WriteLine($"{points[2]} to the right: {m3.Next(points[2], Direction.Right)}");
            Console.WriteLine($"{points[3]} to the left: {m3.Next(points[3], Direction.Left)}");
            Console.WriteLine($"{points[3]} to the southwest: {m3.NextDiagonal(points[3], Direction.Down)}");
            Console.WriteLine($"{points[4]} to the northeast: {m3.NextDiagonal(points[4], Direction.Up)}");
            Console.WriteLine($"{points[5]} to the southeast: {m3.NextDiagonal(points[5], Direction.Right)}");
            Console.WriteLine();
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
        try
        {
            Console.WriteLine("m4:");
            SmallSquareMap m4 = new(8);
            Console.WriteLine("Map created!");
            foreach (var point in points)
            {
                Console.WriteLine($"{point} {(m4.Exist(point) ? "exists" : "doesn't exist")} in m4.");
            }
            Console.WriteLine();
            Console.WriteLine($"{points[5]} upwards: {m4.Next(points[5], Direction.Up)}");
            Console.WriteLine($"{points[5]} to the southwest: {m4.NextDiagonal(points[5], Direction.Down)}");
            Console.WriteLine($"{points[6]} to the southwest: {m4.NextDiagonal(points[6], Direction.Down)}");
            Console.WriteLine($"{points[6]} to the northwest: {m4.NextDiagonal(points[6], Direction.Left)}");
            Console.WriteLine($"{points[6]} to the left: {m4.Next(points[6], Direction.Left)}");
            Console.WriteLine();
        }
        catch
        {
            Console.WriteLine("An error occurred.\n");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        //Lab5a();
        Lab5b();
    }
}
