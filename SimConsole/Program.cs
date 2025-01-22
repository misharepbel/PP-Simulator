 using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        /*SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Creeper("Gorbag"), new Human("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";*/

        BigTorusMap map = new(10, 5);
        List<IMappable> mappables = [new Creeper("Boomer"), new Human("Steve"), new Human("Genius"), new Animals() { Description = "Sheep", Size = 6 }, new Birds { Description = "Ender Dragon", Size = 1, CanFly = true }];
        List<Point> points = [new(2, 2), new(3, 1), new(8, 5), new(7, 3), new(0, 4)];
        string moves = "uuuuu";
        Simulation simulation = new(map, mappables, points, moves);
        
        SimulationHistory simHist = new(simulation);
        LogVisualizer logVisualizer = new(simHist);
        int[] turns = { 0, 1, 2, 3, 4, 5 };
        foreach (var turn in turns)
        {
            logVisualizer.Draw(turn);
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
        }*/
    }
}
