using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private readonly Simulation _simulation;
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (true)
        {
            try
            {
                _simulation.Turn();
                var symbols = new Dictionary<Point, char>();
                foreach (var mappable in _simulation.Mappables)
                {
                    if (symbols.ContainsKey(mappable.Position))
                    {
                        symbols[mappable.Position] = 'X';
                    }
                    else
                    {
                        symbols.Add(mappable.Position, mappable.Symbol);
                    }
                }
                SimulationTurnLog simulationTurnLog = new() { Mappable = _simulation.CurrentMappable.ToString(),
                    Move = _simulation.CurrentMoveName, Symbols = symbols }; 
                TurnLogs.Add(simulationTurnLog);
            }
            catch (Exception)
            {
                break;
            }
        }
    }
}