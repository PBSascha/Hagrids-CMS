namespace Hagrids_CMS.Commands;
using Hagrids_CMS.Core;

public class AddCreatureCommand : ICommand
{
    public string Key => "a";
    public string Description => "Add Creature";

    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Creature Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Creature Species:");
        string species = Console.ReadLine();

        Console.WriteLine("Enter Danger Level:");
        string dangerInput = Console.ReadLine();

        Console.WriteLine("Enter Age:");
        int age = int.Parse(Console.ReadLine());

        if (Enum.TryParse<DangerLevel>(dangerInput, true, out DangerLevel level))
        {
            data.Creatures.Add(new Creature(name, species, level, age));
            Console.WriteLine($"Creature '{name}' added.");
        }
    }
}