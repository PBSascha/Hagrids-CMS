using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.VisualBasic;
using Hagrids_CMS.Core;

namespace Hagrids_CMS.Commands;

public class ShowStatisticsCommand : ICommand
{
    public string Key => "i";
    public string Description => "Show Statistics";

    public void Execute(DataStore data)
    {
        Console.WriteLine($"Total Creatures: {data.Creatures.Count}");
        Console.WriteLine($"Total Students: {data.Students.Count}");
        Console.WriteLine($"Total Assignments: {data.Assignments.Count}");

        var avgDanger = data.Creatures.Any() ? data.Creatures.Average(c => (int)c.DangerLevel) : 0;
        Console.WriteLine($"Average Danger Level: {avgDanger:F2}");

        Creature mostDangerous = data.Creatures.OrderByDescending(c => c.DangerLevel).FirstOrDefault();
        if (mostDangerous != null)            
            Console.WriteLine($"Most Dangerous Creature: {mostDangerous.Name} ({mostDangerous.DangerLevel})");

        var sortedByAge = data.Creatures.OrderByDescending(c => c.Age).ToList();
        Console.WriteLine("Creatures sorted by age:");
        foreach (var c in sortedByAge)
        {
            Console.WriteLine($"{c.Name} - Age: {c.Age}");
        }

        var sortedByDanger = data.Creatures.OrderByDescending(c => c.DangerLevel).ToList();
        Console.WriteLine("Creatures sorted by danger level:");
        foreach (var c in sortedByDanger)
        {
            Console.WriteLine($"{c.Name} - Danger Level: {c.DangerLevel}");
        }
    }
}