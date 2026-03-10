using System.Security.Cryptography;
using System.Text.Unicode;
using Hagrids_CMS;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Clear();

List <Creature> creatures = new List<Creature>();
creatures.Add(new Creature("Norbert", "Norwegian Ridgeback", "High", 2));
creatures.Add(new Creature("Buckbeak", "Hippogriff", "Medium", 5));
creatures.Add(new Creature("Aragog", "Acromantula", "High", 10));
creatures.Add(new Creature("Fawkes", "Phoenix", "Low", 500));
creatures.Add(new Creature("Fluffy", "Three-Headed Dog", "High", 3));
creatures.Add(new Creature("Dobby", "House Elf", "Low", 100));

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
Console.WriteLine("8 Exit");

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
            string? dangerLevel = Console.ReadLine();
            Console.WriteLine("Enter Creature Age:");
            int age = int.Parse(Console.ReadLine());
            creatures.Add(new Creature(name, species, dangerLevel, age));
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
            Console.WriteLine("Exiting...");
            continue;  
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}