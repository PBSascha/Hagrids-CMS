using System;
namespace Hagrids_CMS.Core;

public class DataStore
{
    public List<Creature> Creatures { get; set; } = new();
    public List<Student> Students { get; set; } = new();
    public List<Assignment> Assignments { get; set; } = new();
}
