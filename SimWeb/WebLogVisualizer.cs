using Simulator;

namespace SimWeb;

public class WebLogVisualizer
{
    public SimulationHistory SimHist { get; }
    public WebLogVisualizer(SimulationHistory simHist)
    {
        SimHist = simHist;
    }

    public string Draw(int turnIndex)
    {
        string res = "";
        if (turnIndex == 0)
        {
            res+=("SIMULATION!\n\nStarting positions:\n");
        }
        else
        {
            SimulationTurnLog log = SimHist.TurnLogs[turnIndex];
            res+=($"Turn {turnIndex}:\n");
            res+=($"{log.Mappable.GetType().Name.ToString().ToUpper()}: " +
                $"{log.Mappable.Info} {log.Mappable.Position} " +
                $"goes {log.Move}:\n");

        }
        //Draw the map
        //Upper boundary
        res+=(Box.TopLeft);
        res+=(Box.Horizontal);
        for (int i = 1; i < SimHist.SizeX; i++)
        {
            res+=(Box.TopMid);
            res+=(Box.Horizontal);
        }
        res+=(Box.TopRight+'\n');
        //Data
        for (int i = SimHist.SizeY - 1; i >= 0; i--)
        {
            for (int j = 0; j < SimHist.SizeX; j++)
            {
                res+=(Box.Vertical);
                Point p = new(j, i);
                if (SimHist.TurnLogs.ElementAt(turnIndex).Symbols.TryGetValue(p, out char value))
                {
                    res+=(value);
                }
                else
                {
                    res+=(' ');
                }
            }
            res+=(Box.Vertical+'\n');
            if (i > 0)
            {
                res+=(Box.MidLeft);
                res+=(Box.Horizontal);
                for (int j = 1; j < SimHist.SizeX; j++)
                {
                    res+=(Box.Cross);
                    res+=(Box.Horizontal);
                }
                res+=(Box.MidRight+'\n');
            }
        }
        //Bottom
        res+=(Box.BottomLeft);
        res+=(Box.Horizontal);
        for (int i = 1; i < SimHist.SizeX; i++)
        {
            res+=(Box.BottomMid);
            res+=(Box.Horizontal);
        }
        res+=(Box.BottomRight+'\n');
        return res;
    }
}
