using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class ListAssignmentsCommand : ICommand
{
    public string Key => "h";
    public string Description => "List All Assignments";

    public void Execute(DataStore data)
    {
        foreach(var assignment in data.Assignments)
        {
            Console.WriteLine($"Creature {assignment.creature.Name} is assigned to {assignment.student.Name}.");
        }
    }
}