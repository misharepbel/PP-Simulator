using Simulator;
using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    static void Main(string[] args)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mappables = [
            new Creeper("Gorbag", 3, 5),
            new Human("Elandor", 2, 7),
      ];

        BigTorusMap map = new(8, 6);
        List<Point> points = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
        string moves = "drudlurudrlull";
        Simulation simulation = new(map, mappables, points, moves);
        SimulationHistory SimHist = new(simulation);



        string json = JsonSerializer.Serialize(SimHist, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);



        var deserialized =
            JsonSerializer.Deserialize<SimulationHistory>(json, options)!;
        Console.WriteLine(deserialized);
    }
}
