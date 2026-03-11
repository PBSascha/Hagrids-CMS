using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class FilterDangerLevelCommand : ICommand
{
    public string Key => "j";
    public string Description => "Filter Creatures by Danger Level";

    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Danger Level to Filter (Low, Medium, High, VeryHigh):");
        string? filterInput = Console.ReadLine();

        if (Enum.TryParse<DangerLevel>(filterInput, true, out DangerLevel filterLevel))
        {
            var filteredCreatures = data.Creatures
                .Where(c => c.DangerLevel == filterLevel)
                .ToList();

            if (filteredCreatures.Count > 0)
            {
                foreach (Creature c in filteredCreatures)
                {
                    c.PrintInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No creatures found with that danger level.");
            }
        }
        else
        {
            throw new ArgumentException("Invalid danger level.");
        }
    }
}