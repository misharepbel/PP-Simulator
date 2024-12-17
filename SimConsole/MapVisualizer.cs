using Simulator.Maps;
namespace SimConsole;

public class MapVisualizer
{
    private readonly Map map;
    public MapVisualizer(Map map)
    {
        this.map = map;
    }
    public void Visualize()
    {
        //Upper boundary
        Console.Write(Box.TopLeft);
        Console.Write(Box.Horizontal);
        for (int i = 1; i < map.SizeX; i++)
        {
            Console.Write(Box.TopMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);
        //Data
        for (int i = map.SizeY-1; i >=0; i--)
        {
            for (int j = 0; j < map.SizeX; j++)
            {
                Console.Write(Box.Vertical);
                List<IMappable> field = map.At(j, i);
                if (field.Count == 1)
                {
                    Console.Write(field.ElementAt(0).Symbol);
                }
                else if (field.Count > 1)
                {
                    Console.Write('X');
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
                for (int j = 1; j < map.SizeX; j++)
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
        for (int i = 1; i < map.SizeX; i++)
        {
            Console.Write(Box.BottomMid);
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
