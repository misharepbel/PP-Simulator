using Simulator;
using Simulator.Maps;

internal class Program
{
    private static int CompareCreaturesByLevel(Creature c1, Creature c2)
    {
        return c1.Level.CompareTo(c2.Level);
    }
    private static int CompareCreaturesByPower(Creature c1, Creature c2)
    {
        return c1.Power.CompareTo(c2.Power);
    }
    private static int OverableCreaturesComparison(Creature c1, Creature c2)
    {
        double overabilityC1 = c1 is Elf ? ((Elf)c1).Agility / c1.Level : ((Orc)c1).Rage / c1.Level;
        double overabilityC2 = c2 is Elf ? ((Elf)c2).Agility / c2.Level : ((Orc)c2).Rage / c2.Level;
        return overabilityC1.CompareTo(overabilityC2)*(-1);
    }
    static void Main(string[] args)
    {
        List<Creature> creatures = [new Orc("Gorbag", rage: 2, level: 3), new Elf("Elandor"),
            new Orc("Szambag", level: 4, rage: 25), new Elf("Szambandor", agility: 7),
            new Orc("Marian", rage: 2, level: -10), new Elf("Misha Sha", level: 9, agility: 6),
            new Orc("Kharton", level: 3), new Elf("Van Darkholme", level: 6, agility: 10),
            new Orc("Donald", rage: 200, level: -3), new Elf("Joe", level: 3, agility: 0),
            new Orc("Jarosław Kaczyński", level: 5, rage: 8), new Elf("Alexander Zudin", agility: 7)];

        Console.WriteLine("Unsorted list of creatures:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature.GetType().Name.ToString().ToUpper() + ": " + creature.Info);
        }

        creatures.Sort(CompareCreaturesByPower);
        Console.WriteLine("\nList of creatures sorted by Power:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature.GetType().Name.ToString().ToUpper() + ": " + creature.Info);
        }

        creatures.Sort(CompareCreaturesByLevel);
        Console.WriteLine("\nList of creatures sorted by Level:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature.GetType().Name.ToString().ToUpper() + ": " + creature.Info);
        }

        creatures.Sort((x, y) => { return x.Name.CompareTo(y.Name); });
        Console.WriteLine("\nList of creatures sorted by Name:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature.GetType().Name.ToString().ToUpper() + ": " + creature.Info);
        }

        creatures.Sort(OverableCreaturesComparison);
        Console.WriteLine("\nList of creatures sorted by Overability, descendingly:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature.GetType().Name.ToString().ToUpper() + ": " + creature.Info);
        }
    }
}
