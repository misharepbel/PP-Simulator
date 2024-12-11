using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        /*SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";*/

        BigBounceMap map = new(8, 6);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" }, new Birds() { Description = "Eagles", CanFly = true}, new Birds() { Description = "Ostriches", CanFly = false }];
        List<Point> points = [new(2, 2), new(3, 1), new(0, 4), new(1, 3), new(7, 3)];
        string moves = "dddduddddddddddddddd";

        Simulation simulation = new(map, mappables, points, moves);
        SimulationHistory simHist = new(simulation);
        int[] turns = { 5, 10, 15, 20 };
        foreach (var turn in turns)
        {
            simHist.ShowMove(turn - 1);
        }
        /*MapVisualizer mapVisualizer = new(simulation.Map);
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
                Console.WriteLine($"Turn {turn}:");
                Console.WriteLine($"{simulation.CurrentMappable.GetType().Name.ToString().ToUpper()}: " +
                    $"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} " +
                    $"goes {simulation.CurrentMoveName}:");
                simulation.Turn();
                mapVisualizer.Visualize();
                turn++;
            }
            catch (Exception)
            {
                Console.WriteLine("Simulation has finished!");
                break;
            }
        }*/
    }
}
