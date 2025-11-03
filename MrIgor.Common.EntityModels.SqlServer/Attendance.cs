using System;
using System.Collections.Generic;

namespace Shared.MrIgor;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int SubjectId { get; set; }

    public string StudentId { get; set; } = null!;

    public int ClassroomId { get; set; }

    public DateTime? AttendedAt { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual AspNetUser Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
