using System;

namespace Hagrids_CMS;

public class Assignment
{
    public Student student { get; set; }
    public Creature creature { get; set; }

    public Assignment(Student s, Creature c)
    {
        this.student = s;
        this.creature = c;
    }
}