using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    SimulationHistory SimHist { get; }
    public LogVisualizer(SimulationHistory simHist)
    {
        SimHist = simHist;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex==0)
        {
            Console.WriteLine("SIMULATION!\n\nStarting positions:");
        }
        else
        {
            SimulationTurnLog log = SimHist.TurnLogs[turnIndex];
            Console.WriteLine($"Turn {turnIndex}:");
            //Console.WriteLine($"{log.Mappable} goes {log.Move}");
            Console.WriteLine($"{log.Mappable.GetType().Name.ToString().ToUpper()}: " +
                $"{log.Mappable.Info} {log.Mappable.Position} " +
                $"goes {log.Move}:");

        }
        //Draw the map
        //Upper boundary
        Console.Write(Box.TopLeft);
        Console.Write(Box.Horizontal);
        for (int i = 1; i < SimHist.SizeX; i++)
        {
            Console.Write(Box.TopMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);
        //Data
        for (int i = SimHist.SizeY - 1; i >= 0; i--)
        {
            for (int j = 0; j < SimHist.SizeX; j++)
            {
                Console.Write(Box.Vertical);
                Point p = new(j, i);
                if (SimHist.TurnLogs.ElementAt(turnIndex).Symbols.TryGetValue(p, out char value))
                {
                    Console.Write(value);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine(Box.Vertical);
            if (i > 0)
            {
                Console.Write(Box.MidLeft);
                Console.Write(Box.Horizontal);
                for (int j = 1; j < SimHist.SizeX; j++)
                {
                    Console.Write(Box.Cross);
                    Console.Write(Box.Horizontal);
                }
                Console.WriteLine(Box.MidRight);
            }
        }
        //Bottom
        Console.Write(Box.BottomLeft);
        Console.Write(Box.Horizontal);
        for (int i = 1; i < SimHist.SizeX; i++)
        {
            Console.Write(Box.BottomMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
