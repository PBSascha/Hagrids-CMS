using System;

namespace Hagrids_CMS.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string House { get; set; }
        public int Year { get; set; }

        public Student(string name, string house, int year)
        {
            Name = name;
            House = house;
            Year = year;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"House: {House}");
            Console.WriteLine($"Year: {Year}");
        }

    }
}
