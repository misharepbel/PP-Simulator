using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            //Initializing simulation
            BigTorusMap map = new(8, 6);
            List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Rabbits" }, new Birds() { Description = "Eagles", CanFly = true }, new Birds() { Description = "Ostriches", CanFly = false }];
            List<Point> points = [new(2, 2), new(3, 1), new(5, 5), new(7, 3), new(0, 4)];
            string moves = "dlrludluddlrulr";
            Simulation simulation = new(map, mappables, points, moves);
            SimulationHistory simHist = new(simulation);
            WebLogVisualizer = new(simHist);
            Grid = WebLogVisualizer.Draw(0);
        }
        public int TurnStamp { get; private set; }
        public string Grid { get; private set; }
        public WebLogVisualizer WebLogVisualizer { get; private set; }
        public void OnGet()
        {
            TurnStamp = HttpContext.Session.GetInt32("TurnStamp") ?? 0;
            Grid = HttpContext.Session.GetString("Grid") ?? WebLogVisualizer.Draw(TurnStamp);
        }
        public void OnPostNext()
        {
            TurnStamp = HttpContext.Session.GetInt32("TurnStamp") ?? 0;
            Grid = HttpContext.Session.GetString("Grid") ?? WebLogVisualizer.Draw(TurnStamp);
            if (TurnStamp < WebLogVisualizer.SimHist.TurnLogs.Count-1)
            {
                TurnStamp++;
            }
            HttpContext.Session.SetInt32("TurnStamp", TurnStamp);
            HttpContext.Session.SetString("Grid", WebLogVisualizer.Draw(TurnStamp));
        }
        public void OnPostPrevious()
        {
            TurnStamp = HttpContext.Session.GetInt32("TurnStamp") ?? 0;
            Grid = HttpContext.Session.GetString("Grid") ?? WebLogVisualizer.Draw(TurnStamp);
            if (TurnStamp>0)
            {
                TurnStamp--;
            }
            HttpContext.Session.SetInt32("TurnStamp", TurnStamp);
            HttpContext.Session.SetString("Grid", WebLogVisualizer.Draw(TurnStamp));
        }
    }
}
