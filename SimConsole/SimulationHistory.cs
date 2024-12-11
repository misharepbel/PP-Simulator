using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationHistory
{
    private Simulation simulation;
    private List<List<Point>> allPositions;
    //private MapVisualizer? visualizer;
    private bool showCalled = false;
    public SimulationHistory(Simulation s)
    {
        simulation = s;
        allPositions = [s.Positions];
        while (true)
        {
            try
            {
                s.Turn();
                List<Point> newPositions = [];
                foreach (var mappable in s.Mappables)
                {
                    newPositions.Add(mappable.Position);
                }
                allPositions.Add(newPositions);
            }
            catch (Exception e)
            {
                break;
            }
        }
    }
    public void ShowMove(int turn)
    {
        Console.WriteLine($"Turn {turn + 1}:");
        Console.WriteLine($"{simulation.MappableAt(turn).GetType().Name.ToString().ToUpper()}: " +
            $"{simulation.MappableAt(turn).Info} {allPositions.ElementAt(turn).ElementAt(turn % simulation.Mappables.Count)} " +
            $"goes {simulation.MoveNameAt(turn)}:");
        Map tempMap = simulation.Map;
        tempMap.Clear();
        for (int i = 0; i < simulation.Mappables.Count; i++)
            {
                tempMap.Add(simulation.Mappables.ElementAt(i), allPositions.ElementAt(turn).ElementAt(i));
            }
        var visualizer = new MapVisualizer(tempMap);
        visualizer.Visualize();
    }
}
