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

Console.WriteLine("A Add Creature");
Console.WriteLine("B Show Creatures");
Console.WriteLine("C Find Creature by Name");
Console.WriteLine("D Add Student");
Console.WriteLine("E Show Students");
Console.WriteLine("F Find Student by Name");
Console.WriteLine("G Assign Creature");
Console.WriteLine("H Show Assignments");
Console.WriteLine("I Statistics");
Console.WriteLine("J Filter Creatures");
Console.WriteLine("K Show average danger level");
Console.WriteLine("L Show Creatures sorted by danger level");
Console.WriteLine("M Show Creatures sorted by age");
Console.WriteLine("X Exit");

List<Assignment> assignments = new List<Assignment>();
while (true)
{
    string? input = Console.ReadLine().ToLower();
    switch (input)
    {
        //add creature
        case "a":
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
        //show creatures
        case "b":
            foreach (Creature c in creatures)
            {
                c.PrintInfo();
                Console.WriteLine();
            }
            break;
        //find creature by name
        case "c":
            Console.WriteLine("Enter Creature Name:");
            string? cName = Console.ReadLine();
            Creature creatureInfo = creatures.Find(c => c.Name == cName);
            if (creatureInfo != null)
            {
                creatureInfo.PrintInfo();
            }
            else
            {
                Console.WriteLine("Creature not found.");
            }
            break;
        //add student
        case "d":
            Console.WriteLine("Enter Student Name:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter Student House:");
            string house = Console.ReadLine();
            Console.WriteLine("Enter Student Year:");
            int year = int.Parse(Console.ReadLine());
            students.Add(new Student(studentName, house, year));
            break;
        //show students
        case "e":
            foreach (Student s in students)
            {
                s.PrintInfo();
                Console.WriteLine();
            }
            break;
        //find student by name
        case "f":
            Console.WriteLine("Enter Student Name:");
            string? sName = Console.ReadLine();
            Student studentInfo = students.Find(s => s.Name == sName);
            if (studentInfo != null)
            {
                studentInfo.PrintInfo();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            break;
        //assign creature
        case "g":
            Console.WriteLine("Enter Student Name:");
            string stName = Console.ReadLine();

            Console.WriteLine("Enter Creature Name:");
            string crName = Console.ReadLine();

            Student student = students.Find(s => s.Name == stName);
            Creature creature = creatures.Find(c => c.Name == crName);

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
        //show assignments
        case "h":
            Console.WriteLine("Current Assignments:");
            foreach (Assignment a in assignments)
            {
                Console.WriteLine($"Student: {a.student.Name}, Creature: {a.creature.Name}");
            }
            break;
        //statistics
        case "i":
            Console.WriteLine($"Total Creatures: {creatures.Count}");
            Console.WriteLine($"Total Students: {students.Count}");
            Console.WriteLine($"Total Assignments: {assignments.Count}");
            break;
        //filter creatures
        case "j":
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
                throw new ArgumentException("Invalid danger level.");
            }

            break;   
        //show average danger level    
        case "k":
            double averageDangerLevel = creatures.Average(c => (int)c.DangerLevel);
            Console.WriteLine($"Average Danger Level: {averageDangerLevel:F2}");
            
            Creature mostDangerous = creatures.OrderByDescending(c => c.DangerLevel).FirstOrDefault();
            if (mostDangerous != null)            {
                Console.WriteLine($"Most Dangerous Creature: {mostDangerous.Name} ({mostDangerous.DangerLevel})");
            }

            Console.WriteLine($"Total Creatures: {creatures.Count}");            
            break;
        //show creatures sorted by danger level
        case "l":
            var sortedByDangerLevel = creatures.OrderBy(c => c.DangerLevel).ToList();

            foreach (var c in sortedByDangerLevel)
            {
                c.PrintInfo();
            }
            break;
        //show creatures sorted by age
        case "m":
            var sortedByAge = creatures.OrderByDescending(c => c.Age).ToList();

            foreach (var c in sortedByAge)
            {
                c.PrintInfo();
            }
            break;
        case "x":
            Console.WriteLine("Exiting...");
            continue;  
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}