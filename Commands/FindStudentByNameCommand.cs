using Hagrids_CMS.Core;
namespace Hagrids_CMS.Commands;

public class FindStudentByNameCommand : ICommand
{
    public string Key => "f";
    public string Description => "Find Student by Name";

    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Student Name:");
        string? name = Console.ReadLine();

        var student = data.Students.FirstOrDefault(s => s.Name == name);

        if (student != null)
        {
            student.PrintInfo();
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}