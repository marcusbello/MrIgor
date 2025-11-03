using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Classroom
{
    public int ClassroomId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Location { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
