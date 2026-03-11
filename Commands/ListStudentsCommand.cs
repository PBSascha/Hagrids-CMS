using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class ListStudentsCommand : ICommand
{
    public string Key => "e";
    public string Description => "List Students";

    public void Execute(DataStore data)
    {
        if (data.Students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (var student in data.Students)
        {
            Console.WriteLine($"{student.Name} - {student.House} - Year: {student.Year}");
        }
    }
}