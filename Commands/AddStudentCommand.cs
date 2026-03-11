namespace Hagrids_CMS.Commands;
using Hagrids_CMS.Core;

public class AddStudentCommand : ICommand
{
    public string Key => "d";
    public string Description => "Add Student";

    public void Execute(DataStore data)
    {
        Console.WriteLine("Enter Student Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Student House:");
        string house = Console.ReadLine();

        Console.WriteLine("Enter Student Year:");
        int year = int.Parse(Console.ReadLine());

        data.Students.Add(new Student(name, house, year));
        Console.WriteLine($"Student '{name}' added.");
    }
}