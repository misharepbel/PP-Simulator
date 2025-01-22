using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using System.Text.Json;
using System.Net.Http.Headers;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        
        public SimulationHistory InitSimHist()
        {
            SmallTorusMap map = new(10, 6);
            List<IMappable> mappables = [new Creeper("Boomer"), new Human("Steve"), new Birds(){Description="Chicks", Size=9, CanFly=false}, new Animals() { Description="Sheep", Size=6 }, new Birds { Description="Ender Dragon", Size=1, CanFly=true}];
            List<Point> points = [new(1, 5), new(0, 1), new(8, 4), new(7, 3), new(3, 4)];
            string moves = !string.IsNullOrWhiteSpace(Moves) ? Moves : "uuuuuuuuu";
            Simulation simulation = new(map, mappables, points, moves);
            SimHist = new(simulation);
            return SimHist;
        }

        public string MakeField(SimulationHistory simulationHistory, int turnIndex)
        {
            var temp_mapb = simulationHistory.TurnLogs.ElementAt(turnIndex);
            string res = "";
            if (turnIndex!=0)
            {
                res += $"<h2>Turn {turnIndex}: {temp_mapb.Mappable.GetType().Name.ToString().ToUpper()}:" +
                $" {temp_mapb.Mappable.Info} {temp_mapb.Mappable.Map!.Next(temp_mapb.Mappable.Position,
                Reverse(DirectionParser.Parse(temp_mapb.Move).ElementAt(0)))} goes {temp_mapb.Move}</h2>";
            }
            else
            {
                res += "<h2>Starting positions:</h2>";
            }
            res += "<div class='main-text'>\r\n    " +
                $"<div class='game-board' style='--columns: {simulationHistory.SizeX}; --rows: {simulationHistory.SizeY}'>";
            for (int i = simulationHistory.SizeY - 1; i >= 0; i--)
            {
                for (int j = 0; j < simulationHistory.SizeX; j++)
                {
                    Point p = new(j, i);
                    res += $"<div class='field'>";
                    res += "<img class='board-icon' ";
                    if (simulationHistory.TurnLogs.ElementAt(turnIndex).Symbols.TryGetValue(p, out char value))
                    {
                        
                        switch(value)
                        {
                            case 'C':
                                res+= "src='/images/creeper-1817227_640.png'>";
                                break;
                            case 'H':
                                res += "src='/images/1559756863Minecraft-Png-steve.png'>";
                                break;
                            case 'b':
                                res += "src='/images/1559756861minecraft-clipart-9_l.png'>";
                                break;
                            case 'B':
                                res += "style='filter: brightness(100%);' src='/images/d57o57e-54ee1f59-6239-473e-8656-91cbf255f45a.gif'>";
                                break;
                            case 'A':
                                res += "src='/images/1559756856minecraft-png-33_l.png'>";
                                break;
                            case 'X':
                                res += "src='/images/questions.png'>";
                                break;
                            default:
                                res += "style='opacity: 0;' src='/images/BackgroundPattern253.svg'>";
                                break;
                        }
                    }
                    else
                    {
                        res += "style='opacity: 0;' src='/images/BackgroundPattern253.svg'>";
                    }
                    res+="</div>";
                }
            }
            res += "</div>\r\n</div>";
            return res;
        }
        
        [BindProperty(SupportsGet = true)]
        public string? Moves { get; set; }
        
        public string? Field { get; set; }
        public int TurnStamp { get; private set; }
        public SimulationHistory? SimHist { get; private set; }
        public void OnGet()
        {
            TurnStamp = 0;
            HttpContext.Session.SetInt32("TurnStamp", TurnStamp);
            HttpContext.Session.SetString("Moves", Moves ?? string.Empty);
            SimHist = InitSimHist();
            Field = MakeField(SimHist, TurnStamp);
        }
        public void OnPostNext()
        {
            TurnStamp = HttpContext.Session.GetInt32("TurnStamp") ?? 0;
            Field = HttpContext.Session.GetString("Field") ?? "AAAAAAAAAA";
            Moves = HttpContext.Session.GetString("Moves") ?? string.Empty;
            if (TurnStamp < Moves?.Length)
            {
                TurnStamp++;
            }
            HttpContext.Session.SetInt32("TurnStamp", TurnStamp);
            SimHist = InitSimHist();
            Field = MakeField(SimHist, TurnStamp);
        }
        public void OnPostPrevious()
        {
            TurnStamp = HttpContext.Session.GetInt32("TurnStamp") ?? 0;
            Moves = HttpContext.Session.GetString("Moves") ?? string.Empty;
            if (TurnStamp > 0)
            {
                TurnStamp--;
            }
            HttpContext.Session.SetInt32("TurnStamp", TurnStamp);
            SimHist = InitSimHist();
            Field = MakeField(SimHist, TurnStamp);
        }

        private static Direction Reverse(Direction d)
        {
            return d switch
            {
                Direction.Up => Direction.Down,
                Direction.Right => Direction.Left,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                _ => default,
            };
        }
    }
}
