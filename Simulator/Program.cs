using System.Security.Cryptography;

namespace Simulator;

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
            Rectangle r2 = new Rectangle(new Point(1, 3), new Point(11, 43));
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
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
}
