using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class AssignCreatureCommand : ICommand
{
    public string Key => "g";
    public string Description => "Assign Creature to Student";

    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Student Name:");
        string studentName = Console.ReadLine();

        var student = data.Students.FirstOrDefault(s => s.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase));

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine("Enter Creature Name:");
        string creatureName = Console.ReadLine();

        var creature = data.Creatures.FirstOrDefault(c => c.Name.Equals(creatureName, StringComparison.OrdinalIgnoreCase));

        if (creature == null)
        {
            Console.WriteLine("Creature not found.");
            return;
        }

        data.Assignments.Add(new Assignment(student, creature));
        Console.WriteLine($"Assigned {creature.Name} to {student.Name}.");
    }
}