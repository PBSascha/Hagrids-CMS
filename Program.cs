using System.Security.Cryptography;
using System.Text.Unicode;
using Hagrids_CMS;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Clear();

List <Creature> creatures = new List<Creature>();
creatures.Add(new Creature("Norbert", "Norwegian Ridgeback", DangerLevel.High, 2));
creatures.Add(new Creature("Buckbeak", "Hippogriff", DangerLevel.Medium, 5));
creatures.Add(new Creature("Aragog", "Acromantula", DangerLevel.High, 10));
creatures.Add(new Creature("Fawkes", "Phoenix", DangerLevel.Low, 500));
creatures.Add(new Creature("Fluffy", "Three-Headed Dog", DangerLevel.VeryHigh, 3));
creatures.Add(new Creature("Dobby", "House Elf", DangerLevel.Low, 100));

List <Student> students = new List<Student>();
students.Add(new Student("Harry Potter", "Gryffindor", 11));
students.Add(new Student("Hermione Granger", "Gryffindor", 11));
students.Add(new Student("Ron Weasley", "Gryffindor", 11));
students.Add(new Student("Draco Malfoy", "Slytherin", 11));
students.Add(new Student("Luna Lovegood", "Ravenclaw", 11));

Console.WriteLine("1 Add Creature");
Console.WriteLine("2 Show Creatures");
Console.WriteLine("3 Add Student");
Console.WriteLine("4 Show Students");
Console.WriteLine("5 Assign Creature");
Console.WriteLine("6 Show Assignments");
Console.WriteLine("7 Statistics");
Console.WriteLine("8 Filter Creatures");
Console.WriteLine("9 Exit");

List<Assignment> assignments = new List<Assignment>();
while (true)
{
    string? input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.WriteLine("Enter Creature Name:");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter Creature Species:");
            string? species = Console.ReadLine();
            Console.WriteLine("Enter Creature Danger Level:");
            string? dangerInput = Console.ReadLine();
            Console.WriteLine("Enter Creature Age:");
            int age = int.Parse(Console.ReadLine());
            if (Enum.TryParse<DangerLevel>(dangerInput, true, out DangerLevel dangerLevel))
            {
                creatures.Add(new Creature(name, species, dangerLevel, age));
                Console.WriteLine("Creature added.");
            }
            else
            {
                Console.WriteLine("Invalid danger level.");
            }
            break;
        case "2":
            foreach (Creature c in creatures)
            {
                c.PrintInfo();
                Console.WriteLine();
            }
            break;
        case "3":
            Console.WriteLine("Enter Student Name:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter Student House:");
            string house = Console.ReadLine();
            Console.WriteLine("Enter Student Year:");
            int year = int.Parse(Console.ReadLine());
            students.Add(new Student(studentName, house, year));
            break;
        case "4":
            foreach (Student s in students)
            {
                s.PrintInfo();
                Console.WriteLine();
            }
            break;
        case "5":
            Console.WriteLine("Enter Student Name:");
            string sName = Console.ReadLine();
            Console.WriteLine("Enter Creature Name:");
            string cName = Console.ReadLine();
            Student student = students.Find(s => s.Name == sName);
            Creature creature = creatures.Find(c => c.Name == cName);
            if (student != null && creature != null)
            {
                Assignment assignment = new Assignment(student, creature);
                assignments.Add(assignment);
                Console.WriteLine($"Assigned {creature.Name} to {student.Name}");
            }
            else
            {
                Console.WriteLine("Student or Creature not found.");
            }
            break;
        case "6":
            foreach (Assignment a in assignments)
            {
                Console.WriteLine($"Student: {a.student.Name}, Creature: {a.creature.Name}");
            }
            break;
        case "7":
            Console.WriteLine($"Total Creatures: {creatures.Count}");
            Console.WriteLine($"Total Students: {students.Count}");
            Console.WriteLine($"Total Assignments: {assignments.Count}");
            break;
        case "8":
            Console.WriteLine("Enter Danger Level to Filter (Low, Medium, High, VeryHigh):");
            string? filterInput = Console.ReadLine();

            if (Enum.TryParse<DangerLevel>(filterInput, true, out DangerLevel filterLevel))
            {
                var filteredCreatures = creatures
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
                Console.WriteLine("Invalid danger level.");
            }

            break;       
        case "9":
            Console.WriteLine("Exiting...");
            continue;  
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}