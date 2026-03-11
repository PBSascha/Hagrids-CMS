using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class FindCreatureByNameCommand : ICommand
{
    public string Key => "c";
    public string Description => "Find Creature by Name";
    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Creature Name:");
        string name = Console.ReadLine();

        var creature = data.Creatures.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (creature != null)
        {
            Console.WriteLine($"{creature.Name} - {creature.Species} - Danger: {creature.DangerLevel} - Age: {creature.Age}");
        }
        else
        {
            Console.WriteLine($"Creature '{name}' not found.");
        }
    }
}