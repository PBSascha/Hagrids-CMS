using Hagrids_CMS.Models;
using Hagrids_CMS.Commands;
using Hagrids_CMS.Core;
using System.Reflection;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Clear();

DataStore data = new();
data.Creatures.Add(new Creature("Norbert", "Norwegian Ridgeback", DangerLevel.High, 2));
data.Creatures.Add(new Creature("Buckbeak", "Hippogriff", DangerLevel.Medium, 5));
data.Creatures.Add(new Creature("Aragog", "Acromantula", DangerLevel.High, 10));
data.Creatures.Add(new Creature("Fawkes", "Phoenix", DangerLevel.Low, 500));
data.Creatures.Add(new Creature("Fluffy", "Three-Headed Dog", DangerLevel.VeryHigh, 3));
data.Creatures.Add(new Creature("Dobby", "House Elf", DangerLevel.Low, 100));

data.Students.Add(new Student("Harry Potter", "Gryffindor", 11));
data.Students.Add(new Student("Hermione Granger", "Gryffindor", 11));
data.Students.Add(new Student("Ron Weasley", "Gryffindor", 11));
data.Students.Add(new Student("Draco Malfoy", "Slytherin", 11));
data.Students.Add(new Student("Luna Lovegood", "Ravenclaw", 11));

var commands = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(t => (ICommand)Activator.CreateInstance(t))
    .ToList();

while (true)
{
    Console.WriteLine();

    foreach (var cmd in commands.OrderBy(c => c.Key))
    {
        Console.WriteLine($"{cmd.Key.ToUpper()} {cmd.Description}");
    }

    Console.WriteLine("X Exit");

    string input = Console.ReadLine().ToLower();

    if (input == "x")
        break;

    var command = commands.FirstOrDefault(c => c.Key == input);

    if (command != null)
        command.Execute(data);
    else
        Console.WriteLine("Invalid option.");
}