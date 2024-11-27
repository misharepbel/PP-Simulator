using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        Console.WriteLine("SIMULATION!\n\nStarting positions:");
        mapVisualizer.Visualize();
        int turn = 1;
        while (true)
        {
            try
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                simulation.Turn();
                Console.WriteLine($"Turn {turn}:");
                Console.WriteLine($"{simulation.CurrentMappable.GetType().Name.ToString().ToUpper()}: " +
                    $"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} " +
                    $"goes {simulation.CurrentMoveName}:");
                mapVisualizer.Visualize();
                turn++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                break;
            }
        }
    }
}
