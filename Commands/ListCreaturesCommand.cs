using Hagrids_CMS.Core;

namespace Hagrids_CMS.Commands;

public class ListCreaturesCommand : ICommand
{
    public string Key => "b";
    public string Description => "List Creatures";

    public void Execute(DataStore data)
    {
        if (data.Creatures.Count == 0)
        {
            Console.WriteLine("No creatures found.");
            return;
        }

        foreach (var creature in data.Creatures)
        {
            Console.WriteLine($"{creature.Name} - {creature.Species} - Danger: {creature.DangerLevel} - Age: {creature.Age}");
        }
    }
}